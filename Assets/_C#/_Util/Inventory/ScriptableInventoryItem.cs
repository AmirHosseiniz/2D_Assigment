using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableInventoryItem : ScriptableObject, IInventoryItem
{
    [SerializeField] string id;
    [SerializeField] int defaultValue;
    [SerializeField] bool alwaysDisplayUI;
    [SerializeField] Sprite icon;

    public Sprite Icon => icon;
    public int DefaultValue { get => defaultValue; }
    public bool AlwaysDisplayUI { get => alwaysDisplayUI; }

    public string ItemName => id;
}
