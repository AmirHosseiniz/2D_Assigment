using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collectable graphic displayer 

public class CollectableDisplayer : MonoBehaviour
{
    [SerializeField] Collectable collectable;

    [SerializeField] SpriteRenderer graphic;

    private void Start()
    {
        graphic.sprite = collectable.Item.Icon;
    }
}
