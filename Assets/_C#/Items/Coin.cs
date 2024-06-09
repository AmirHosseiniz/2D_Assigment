using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is only a type and data holder fo the cin item
// inventory system uses the data in this object to store values 
// but no value directly saves here, it get save in the inventory and on playerPrefs as a json
// we should create a class for each item like this

[CreateAssetMenu(menuName = "Inventory/Coin")]
public class Coin : ScriptableInventoryItem
{

}
