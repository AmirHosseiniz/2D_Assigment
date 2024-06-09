using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

// wrapper class for player inventory 

public class PlayerInventory : Inventory.Inventory, IInventory
{
    [SerializeField] ScriptableInventory playerScriptableInventory;

    public Transform Transform { get => transform; }

    public bool IsPlayer => true;

    private void Awake()
    {
        playerScriptableInventory.ConnectedInventory = this;
    }

    public void Add(IInventoryItem item, int amount, Transform originTransform = null) => base.Add(item.ItemName, amount, originTransform);
    public void Remove(IInventoryItem item, int amount, Transform originTransform = null) => base.Remove(item.ItemName, amount, originTransform);

    public int GetItemAmount(IInventoryItem item) => base.GetItemAmount(item.ItemName);
    public bool HasItem(IInventoryItem item, out int amount) => base.HasItem(item.ItemName, out amount);
}
