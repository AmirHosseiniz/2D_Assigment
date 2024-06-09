using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public interface IInventory
{
    public Dictionary<string, int> InventoryItems { get; }

    public bool HasItem(IInventoryItem item, out int amount);
    public int GetItemAmount(IInventoryItem item);

    public void Add(IInventoryItem item, int amount, Transform originTransform = null);

    public void Remove(IInventoryItem item, int amount, Transform originTransform = null);

    public bool IsPlayer { get; }

    public Transform Transform { get; }
}
