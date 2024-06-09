using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Inventory;

public class InventoryUIItemDisplayer : InventoryUIItem
{
    [SerializeField] TextMeshProUGUI valueText;

    [SerializeField] Image myIcon;

    ScriptableInventoryItem inventoryItem;

    public override IInventoryItem InventoryItem => inventoryItem;

    public override Transform IconTransform => myIcon.transform;

    public static InventoryUIItemDisplayer Create(InventoryUIItemDisplayer prefab, ScriptableInventoryItem inventoryItem, Transform parent)
    {
        InventoryUIItemDisplayer inventoryUI = Instantiate(prefab, parent);
        inventoryUI.inventoryItem = inventoryItem;
        return inventoryUI;
    }

    public override void OnInit(int itemValue)
    {
        valueText.text = itemValue.ToString();
        myIcon.sprite = inventoryItem.Icon;
    }

    public override void OnValueUpdated(int oldValue, int newValue, Transform originTransform)
    {
        valueText.text = newValue.ToString();
    }

    public override void SetVisibility(bool isVisible)
    {
        if (inventoryItem.AlwaysDisplayUI)
        {
            gameObject.SetActive(true);
            return;
        }
        gameObject.SetActive(isVisible);
    }

    public override void AfterValueAdded()
    {

    }
}
