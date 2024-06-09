using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all the movement needed for player 
// gets the input data from input manager 
// we can seperate the jump and horizontall movement for cleaner code and move them to their own state class
// but since the code is very small here there is no need

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] float movingSpeed;
    [SerializeField] float catchUpSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] PlayerGroundChecker groundChecker;

    [SerializeField] WonEvent wonEvent;
    [SerializeField] InputProvider inputProvider;

    Rigidbody2D myRigidbody;

    Vector2 direction;
    Vector2 velocity;

    Vector2 moveValue;

    bool isJumping = false;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ConnectToInput();

        wonEvent.RegisterListener(DisConnectFromInput);
        wonEvent.RegisterListener(OnLevelWon);
    }

    private void OnDestroy()
    {
        DisConnectFromInput();

        wonEvent.UnRegisterListener(DisConnectFromInput);
        wonEvent.UnRegisterListener(OnLevelWon);
    }

    void FixedUpdate()
    {
        direction = transform.right * moveValue;
        Vector3 newVel = Vector3.MoveTowards(velocity, direction * movingSpeed, catchUpSpeed * Time.fixedDeltaTime);
        velocity = new Vector2(newVel.x, myRigidbody.velocity.y);

        myRigidbody.velocity = velocity;
    }

    void OnInputValueChanged(Vector2 value)
    {
        moveValue = value;
    }

    void OnJump()
    {
        if (!groundChecker.IsGrounded)
            return;

        Jump();
    }

    void Jump()
    {
        myRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void ConnectToInput()
    {
        inputProvider.InputValueEvent += OnInputValueChanged;
        inputProvider.JumpEvent += OnJump;
    }

    void DisConnectFromInput()
    {
        inputProvider.InputValueEvent -= OnInputValueChanged;
        inputProvider.JumpEvent -= OnJump;
    }

    void OnLevelWon()
    {
        moveValue = Vector2.zero;
        myRigidbody.velocity = Vector2.zero;
    }
}
