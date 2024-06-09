using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// check and set the highest score 
// i have two method for calculating it 
// becuz i dont know wich one is desired in the ducoment

public class PlayerHighScoreHandler : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] Coin coin;

    private void Start()
    {
        inventory.ItemValueChangedEvent += OnImventoryItemsChanged;
    }

    private void OnDestroy()
    {
        inventory.ItemValueChangedEvent -= OnImventoryItemsChanged;
    }

    void OnImventoryItemsChanged(string itemName, int oldV, int newV, Transform _)
    {
        //if the item that hav added to the inventory is coin
        if (!string.Equals(itemName, coin.ItemName))
            return;

        // **** if we want to have only the same level that we are in high score to be saved than this code below should get executed
        //***********************************************
        //if (PlayerCoin_HighScore.Value >= newV)
        //    return;
        //PlayerCoin_HighScore.Value = newV ;
        //***********************************************

        // **** if we want to have the general anmount of coin collected to be saved as the high score than this code below should get executed
        //***********************************************
        PlayerCoin_HighScore.Value += (newV - oldV);
        //***********************************************

    }
}
