using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectables
{
    public int Value {  get; set; }
    public bool IsCollectable { get; set; }
    public ScriptableInventoryItem Item { get; }

    public Action OnCollectedEvent {  get; set; }

    public void OnCollect();
}
