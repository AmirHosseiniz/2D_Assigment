using UnityEngine;
using System;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Inventory/ScriptableInventory")]
    public class ScriptableInventory : ScriptableObject
    {
        public Inventory ConnectedInventory { get; set; }

    }
}
