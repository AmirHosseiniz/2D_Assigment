using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryUIDisplayer_Base : MonoBehaviour
{
    protected abstract Inventory.Inventory m_inventory { get; }
    protected Dictionary<string, InventoryUIItem> itemUIs = new Dictionary<string, InventoryUIItem>();

    protected virtual void Start()
    {
        m_inventory.ItemValueChangedEvent += OnUpdateValue;
    }

    protected abstract void CreateAllUIItems();
    protected abstract void CreateUIItems(string itemName);

    protected virtual void AddItemUI(InventoryUIItem itemUI)
    {
        if (itemUIs.ContainsKey(itemUI.InventoryItem.ItemName))
            return;

        itemUIs.Add(itemUI.InventoryItem.ItemName, itemUI);
    }

    protected virtual void RemoveItemUI(InventoryUIItem itemUI)
    {
        if (!itemUIs.ContainsKey(itemUI.InventoryItem.ItemName))
            return;

        itemUIs.Remove(itemUI.InventoryItem.ItemName);
    }

    protected virtual void OnUpdateValue(string itemName, int oldValue, int newValue, Transform originTransform)
    {
        if (itemUIs.TryGetValue(itemName, out var itemUI))
            itemUI.OnValueUpdated(oldValue, newValue, originTransform);
        else if (newValue != 0)
            CreateUIItems(itemName);
    }
}
