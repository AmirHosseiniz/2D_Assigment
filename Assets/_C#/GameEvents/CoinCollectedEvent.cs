using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this event gets triggered when a coin is collected 

[CreateAssetMenu(menuName = "GameEvents/CoinCollectedEvent")]
public class CoinCollectedEvent : GameEvent
{
    protected override bool runOnce => false;
}
