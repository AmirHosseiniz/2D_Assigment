using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;

public class InventoryUIDisplayer : InventoryUIDisplayer_Base
{
    public static InventoryUIDisplayer Instance { get; private set; }

    [SerializeField] List<ScriptableInventoryItem> itemsToDiplay;

    [SerializeField] InventoryUIItemDisplayer uiDisplayerPrefab;

    [SerializeField] ScriptableInventory scriptableInventory;

    bool shouldSendSplash = true;

    Dictionary<string, ScriptableInventoryItem> splashItems = new Dictionary<string, ScriptableInventoryItem>();

    protected override Inventory.Inventory m_inventory => scriptableInventory.ConnectedInventory;


    private void Awake()
    {
        Instance = this;
    }

    protected override void Start()
    {
        CreateAllUIItems();

        base.Start();
    }

    protected virtual void OnDisable()
    {
        m_inventory.ItemValueChangedEvent -= OnUpdateValue;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    protected override void CreateAllUIItems()
    {
        for (int i = 0; i < itemsToDiplay.Count; i++)
        {
            if (!m_inventory.HasItem(itemsToDiplay[i].ItemName, out int _) && !itemsToDiplay[i].AlwaysDisplayUI)
                continue;

            CreateInventoryUIItem(itemsToDiplay[i]);
        }
    }

    protected override void CreateUIItems(string itemName)
    {
        ScriptableInventoryItem inventoryItem = itemsToDiplay.Find(x => x.ItemName == itemName);

        if (!inventoryItem)
            return;

        CreateInventoryUIItem(inventoryItem);
    }

    void CreateInventoryUIItem(ScriptableInventoryItem inventoryItem)
    {
        InventoryUIItemDisplayer inventoryUIItem = InventoryUIItemDisplayer.Create(uiDisplayerPrefab, inventoryItem, transform);
        AddItemUI(inventoryUIItem);
    }

    protected override void AddItemUI(InventoryUIItem itemUI)
    {
        base.AddItemUI(itemUI);
        itemUI.OnInit(m_inventory.GetItemAmount(itemUI.InventoryItem.ItemName));
    }

    protected override void RemoveItemUI(InventoryUIItem itemUI)
    {
        ScriptableInventoryItem inventoryItem = itemsToDiplay.Find(x => x.ItemName == itemUI.InventoryItem.ItemName);
        if (!inventoryItem.AlwaysDisplayUI)
            base.RemoveItemUI(itemUI);
        itemUI.SetVisibility(false);
    }

    protected override void OnUpdateValue(string itemName, int oldValue, int newValue, Transform originTransform)
    {
        base.OnUpdateValue(itemName, oldValue, newValue, originTransform);

        if (newValue <= 0 && itemUIs.ContainsKey(itemName))
            RemoveItemUI(itemUIs[itemName]);
        else if (newValue > oldValue)
        {
            if (itemUIs.ContainsKey(itemName))
                itemUIs[itemName].AfterValueAdded();
        }
    }
}
