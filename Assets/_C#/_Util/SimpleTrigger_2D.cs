using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleTrigger_2D : MonoBehaviour
{
    public Collider MyCollider { get; private set; }

    public Action<Collider2D> onTriggerEnterEvent;
    public Action<Collider2D> onTriggerStayEvent;
    public Action<Collider2D> onTriggerExitEvent;

    private void OnEnable()
    {
        MyCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        onTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExitEvent?.Invoke(other);
    }
}
