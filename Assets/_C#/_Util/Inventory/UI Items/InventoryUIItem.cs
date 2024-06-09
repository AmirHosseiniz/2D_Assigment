using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryUIItem : MonoBehaviour
{
    public abstract Transform IconTransform { get; }
    public abstract IInventoryItem InventoryItem { get; }
    public abstract void OnValueUpdated(int oldValue, int newValue, Transform originTransform);
    public abstract void OnInit(int itemValue);
    public abstract void SetVisibility(bool isVisible);
    public abstract void AfterValueAdded();
}
