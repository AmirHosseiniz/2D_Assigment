using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this event gets triggered when we won the game 
// winning logic is determend by level controller

[CreateAssetMenu(menuName = "GameEvents/WonEvent")]
public class WonEvent : GameEvent
{
    protected override bool runOnce => false;
}
