using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for collecting the collectables 
// checjs for trigger base on the collided layer 

public abstract class CollectablesCollector : MonoBehaviour
{
    [SerializeField] protected SimpleTrigger_2D simpleTrigger;

    [SerializeField] protected LayerMask collectablesLayer;

    protected virtual void Start()
    {
        // sub to trigger event 
        simpleTrigger.onTriggerEnterEvent += OnEnteredTrigger;
    }

    protected virtual void OnDestroy()
    {
        // un sub to trigger event 
        simpleTrigger.onTriggerEnterEvent -= OnEnteredTrigger;
    }

    protected virtual void OnEnteredTrigger(Collider2D collider)
    {
        // check to see the collided object is valid

        if (collider == null || !collider.gameObject.HasLayerMask(collectablesLayer))
            return;

        var collectable = collider.GetComponent<CollectablesPointer>().Collectable;

        if (collectable == null || !collectable.IsCollectable)
            return;

        Collect(collectable);
    }

    protected virtual void Collect(ICollectables collectable)
    {
        // collect 

        collectable.OnCollect();
    }
}
