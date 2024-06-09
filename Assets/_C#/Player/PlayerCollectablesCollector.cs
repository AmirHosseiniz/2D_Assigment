using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class detects the collectables 
// it inherits from the base class 
// the sub class (this) is in controll of adding the items to inventory

public class PlayerCollectablesCollector : CollectablesCollector
{
    [SerializeField] PlayerInventory inventory;

    protected override void Collect(ICollectables collectable)
    {
        inventory.Add(collectable.Item, collectable.Value);

        base.Collect(collectable);
    }
}
