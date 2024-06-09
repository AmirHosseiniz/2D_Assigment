using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Inventory
{
    public abstract class InventoryUIManager : MonoBehaviour
    {
        protected abstract Inventory m_inventory { get; }
        [SerializeField][Label("Inventory Item UIs")] List<InventoryItemUI> inventoryItemUIs;
        Dictionary<string, InventoryItemUI> itemUIs = new Dictionary<string, InventoryItemUI>();


        protected virtual void Start()
        {
            m_inventory.ItemValueChangedEvent += OnUpdateValue;

            inventoryItemUIs.ForEach(x =>
            {
                AddItemUI(x);
                x.OnInit(m_inventory.GetItemAmount(x.InventoryItem.ItemName));
            });

        }

        protected virtual void AddItemUI(InventoryItemUI itemUI)
        {
            itemUIs.Add(itemUI.InventoryItem.ItemName, itemUI);
        }

        protected virtual void OnUpdateValue(string itemName, int oldValue, int newValue, Transform originTransform)
        {
            if (itemUIs.TryGetValue(itemName, out var itemUI))
                itemUI.OnValueUpdated(oldValue, newValue, originTransform);
        }

    }
}
