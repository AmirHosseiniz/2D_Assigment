using UnityEngine;

namespace Inventory
{
    public abstract class InventoryItemUI : MonoBehaviour
    {
        public abstract IInventoryItem InventoryItem { get; }
        public abstract void OnValueUpdated(int oldValue, int newValue, Transform originTransform);
        public abstract void OnInit(int itemValue);
    }
}
