using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// check if the player is grounded or not

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] float checkDst;
    [SerializeField] LayerMask groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        // ray casting 
        Debug.DrawRay(transform.position, Vector3.down * checkDst, Color.red);
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkDst, groundLayer);
    }
}
