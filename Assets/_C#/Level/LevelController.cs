using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] LevelData levelData;

    [SerializeField] CoinCollectedEvent coinCollectedEvent;

    [SerializeField] WonEvent weaponEvent;

    int currentCoinCount;

    private void Start()
    {
        // sub to coin collect event
        coinCollectedEvent.RegisterListener(OnCoinCollected);
    }

    private void OnDestroy()
    {
        // un sub to coin collect event
        coinCollectedEvent.UnRegisterListener(OnCoinCollected);
    }

    void OnCoinCollected()
    {
        currentCoinCount++;

        CheckForCoins();
    }

    void CheckForCoins()
    {
        // check for coins to end the level 

        if (currentCoinCount >= levelData.CoinToCollect)
        {
            weaponEvent.Raise();
            WinPanel.ShowPanel();
        }
    }
}
