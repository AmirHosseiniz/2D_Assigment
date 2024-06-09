using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Inventory
{
    [DefaultExecutionOrder(-3000)]
    [RequireComponent(typeof(Inventory))]
    public class InventoryStoringManager : MonoBehaviour
    {
        [SerializeField] protected string inventoryPrefsKey;

        [SerializeField] bool saveOnInventoryChanges;

        protected Inventory m_inventory;

        protected virtual void Awake()
        {
            m_inventory = GetComponent<Inventory>();

            if (saveOnInventoryChanges)
                m_inventory.ItemValueChangedEvent += SaveValueOnInventoryChanges;

            LoadValue();
        }

        void SaveValueOnInventoryChanges(string name, int oldV, int newV, Transform tr)
        {
            SaveValue();
        }

        protected virtual void LoadValue()
        {

            if (!PlayerPrefs.HasKey(inventoryPrefsKey))
            {
                return;
            }

            var json = PlayerPrefs.GetString(inventoryPrefsKey);
            var data = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);

            foreach (var item in data)
            {
                m_inventory.Add(item.Key, item.Value , null);
            }
        }

        protected virtual void SaveValue()
        {
            var json = JsonConvert.SerializeObject(m_inventory.InventoryItems);
            PlayerPrefs.SetString(inventoryPrefsKey, json);
        }

        protected virtual void OnDestroy()
        {
            SaveValue();

            if (saveOnInventoryChanges)
                m_inventory.ItemValueChangedEvent -= SaveValueOnInventoryChanges;
        }
        private void OnApplicationPause(bool pause)
        {
            if (pause)
                SaveValue();
        }
        private void OnApplicationQuit()
        {
            SaveValue();
        }
    }
}
