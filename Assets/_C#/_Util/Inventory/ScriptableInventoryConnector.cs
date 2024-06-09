using UnityEngine;

namespace Inventory
{
    [DefaultExecutionOrder(-3000)]
    [RequireComponent(typeof(Inventory))]
    public class ScriptableInventoryConnector : MonoBehaviour
    {
        [SerializeField] ScriptableInventory scriptableInventory;

        void Awake()
        {
            var inventory = GetComponent<Inventory>();
            scriptableInventory.ConnectedInventory = inventory;
        }
    }
}
