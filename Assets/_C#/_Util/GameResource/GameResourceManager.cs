using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public partial class GameResourceManager : MonoBehaviour
{
    public static GameResourceManager Instance;
    List<GameResource> dataSources = new List<GameResource>();

    private void Awake()
    {
        Instance = this;
        foreach(var field in GetType().GetFields())
        {
            var resource = field.GetValue(this) as GameResource;
            if (resource != null)   dataSources.Add(resource);
        }
        dataSources = dataSources.OrderBy(x => x.InitOrder).ToList();
        foreach (var dataSource in dataSources)
        {
            dataSource.OnAwake();
        }
    }

    public static GameResource FindEventByType(System.Type t) => Instance.dataSources.Find(x => x.GetType() == t);

    private void OnDestroy()
    {
        dataSources.ForEach(dataSource => dataSource.ClearEvents());
        Instance = null;
    }

}
