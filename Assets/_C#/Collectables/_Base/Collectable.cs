using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for all the collectables with its attributes

public abstract class Collectable : MonoBehaviour, ICollectables
{
    [SerializeField] ScriptableInventoryItem item;

    [SerializeField] int defaultValue = 1;

    int currentValue;

    public ScriptableInventoryItem Item => item;

    public int Value { get => currentValue; set => currentValue = value; }
    public virtual bool IsCollectable { get; set; }

    public Action OnCollectedEvent { get; set; }

    public virtual void OnCollect()
    {
        OnCollectedEvent?.Invoke();
    }

    protected virtual void Start()
    {
        currentValue = defaultValue;
    }
}
