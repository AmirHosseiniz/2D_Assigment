using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EventsManagerBase<T> : MonoBehaviour where T : EventsManagerBase<T>
{
    public static EventsManagerBase<T> Instance { get; private set; }
    List<GameEventBase> gameEvents = new List<GameEventBase>();

    private void Awake()
    {
        Instance = this;
        foreach (var field in GetType().GetFields())
        {
            var resource = field.GetValue(this) as GameEventBase;
            if (resource != null) gameEvents.Add(resource);
        }
        gameEvents = gameEvents.OrderBy(x => x.InitOrder).ToList();
        foreach (var gameEvent in gameEvents)
        {
            gameEvent.OnAwake();
        }
    }
    public static GameEventBase FindEventByType(System.Type t) => Instance.gameEvents.Find(x => x.GetType() == t);
    protected virtual void OnDestroy()
    {
        gameEvents.ForEach(gameEvent => gameEvent.Clear());
        Instance = null;
    }

}

