using System;
using UnityEngine;

public abstract class SimpleGameResource<T1,T2> : GameResource<T2> where T1 : SimpleGameResource<T1,T2>
{
    protected static T1 ResourceObject { get; private set; }

    public static void Register(Action<T2> action) => ResourceObject.RegisterListener(action);
    public static void UnRegister(Action<T2> action) => ResourceObject.UnRegisterListener(action);

    public static T2 Value
    {
        get => ResourceObject.value;
        set => ResourceObject.value = value;
    }

    public override void OnAwake()
    {
        ResourceObject = (T1)GameResourceManager.FindEventByType(typeof(T1));
        base.OnAwake();
    }
}

public abstract class GameResource<T> : GameResource
{
    [SerializeField] protected T defaultValue;
    protected Action<T> listener;

    T _value { get; set; }

    public virtual T value
    {
        get => _value;
        set
        {
            T previousValue = _value;
            _value = value;
            SaveValue();
            OnValueChanged(previousValue, value);
            listener?.Invoke(value);
        }
    }

    protected abstract T LoadValue();
    protected abstract void SaveValue();
    protected virtual void OnValueChanged(T previousVal, T newVal) { }

    public void RegisterListener(Action<T> action)
    {
        listener += action;
    }
    public void UnRegisterListener(Action<T> action)
    {
        listener -= action;
    }
    public override void ClearEvents()
    {
        listener = null;
    }
    public override void OnAwake()
    {
        _value = LoadValue();
    }

}
public abstract class GameResource : ScriptableObject
{
    public virtual int InitOrder { get; private set; } = 0;
    protected abstract string PrefsKey { get; }
    public abstract void ClearEvents();
    public abstract void OnAwake();
}
