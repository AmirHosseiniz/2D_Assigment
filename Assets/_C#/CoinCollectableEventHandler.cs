using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectableEventHandler : MonoBehaviour
{
    [SerializeField] Collectable collectable;
    [SerializeField] CoinCollectedEvent collectedEvent;

    private void Start()
    {
        collectable.OnCollectedEvent += OnCollectableCollected;
    }

    private void OnDestroy()
    {
        collectable.OnCollectedEvent -= OnCollectableCollected;
    }

    void OnCollectableCollected()
    {
        collectedEvent.Raise();
    }
}
