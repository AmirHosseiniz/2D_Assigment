using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

// encapsulated input manager wich will be automaticlly spawned in the scene by input provider 
// we can add more logic for input here or seperate the different input methode by its classes 
// and it help with the seperation of concerns principle

public class InputManager : MonoBehaviour
{
    [SerializeField] bool horizontalMove = true;
    [SerializeField] bool verticalMove = true;

    Vector2 _inputvalue = Vector2.zero;

    public event Action<Vector2> InputValueEvent;
    public event Action JumpEvent;

    void Update()
    {
        CheckForHorizontal();

        CheckForVertical();

        CheckForJump();

        InputValueEvent?.Invoke(_inputvalue);
    }

    void CheckForHorizontal()
    {
        if (horizontalMove && Input.GetButton("Horizontal"))
            _inputvalue.x = Input.GetAxis("Horizontal");

        if (horizontalMove && Input.GetButtonUp("Horizontal"))
            _inputvalue.x = 0;
    }

    void CheckForVertical()
    {
        if (verticalMove && Input.GetButton("Vertical"))
            _inputvalue.y = Input.GetAxis("Vertical");

        if (verticalMove && Input.GetButtonUp("Vertical"))
            _inputvalue.y = 0;
    }

    void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            JumpEvent?.Invoke();
    }
}