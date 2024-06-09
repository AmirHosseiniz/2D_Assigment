using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// encapsulated  data for our level 

[CreateAssetMenu(menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] int coinToCollect;

    public int CoinToCollect => coinToCollect;
}
