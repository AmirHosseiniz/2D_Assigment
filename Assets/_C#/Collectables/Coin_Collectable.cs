using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collectable : Collectable
{
    bool isCollectable = true;

    public override bool IsCollectable { get => isCollectable; set => isCollectable = value; }

    public override void OnCollect()
    {
        // action on collect which we want to happen
        base.OnCollect();
        gameObject.SetActive(false);
    }
}
