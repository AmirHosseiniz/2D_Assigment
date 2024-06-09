using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public Action<string, int, int, Transform> ItemValueChangedEvent { get; set; }

        public Dictionary<string, int> InventoryItems { get; private set; } = new Dictionary<string, int>();
        public int ItemsCount { get; private set; }

        public void Add(string itemName, int amount, Transform originTransform)
        {
            if (!InventoryItems.ContainsKey(itemName))
                InventoryItems.Add(itemName, 0);
            var oldValue = InventoryItems[itemName];
            var newValue = oldValue + amount;
            InventoryItems[itemName] = newValue;
            ItemsCount += amount;
            ItemValueChangedEvent?.Invoke(itemName, oldValue, newValue, originTransform);
        }

        public void Remove(string itemName, int amount, Transform originTransform)
        {
            if (!InventoryItems.ContainsKey(itemName) || InventoryItems[itemName] < amount)
                return;
            var oldValue = InventoryItems[itemName];
            var newValue = oldValue - amount;
            InventoryItems[itemName] = newValue;
            ItemsCount -= amount;

            ItemValueChangedEvent?.Invoke(itemName, oldValue, newValue, originTransform);
        }

        public bool HasItem(string itemName, out int amount)
        {
            amount = 0;

            if (!InventoryItems.ContainsKey(itemName) || InventoryItems[itemName] == 0)
                return false;

            amount = InventoryItems[itemName];
            return true;
        }

        public int GetItemAmount(string itemName)
        {
            HasItem(itemName, out var amount);
            return amount;
        }
    }
}
