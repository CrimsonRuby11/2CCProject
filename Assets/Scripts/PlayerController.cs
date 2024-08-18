using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public InputManager inputManager;

    [SerializeField]
    internal float playerSpeed, jumpSpeed, plungeSpeed;
    [SerializeField]
    internal Animator playerAnimator;
    [SerializeField]
    internal Rigidbody2D rb;

    private InputAction jumpAction;
    private InputAction plungeAction;

    // States
    internal PlayerBaseState currentState;
    internal PlayerIdle playerIdle;
    internal PlayerMove playerMove;
    internal PlayerJump playerJump;
    internal PlayerPlunge playerPlunge;

    public void Awake() {

        if(instance == null) instance = this;
        else if(instance != this) Destroy(this);

        inputManager = new InputManager();
        jumpAction = inputManager.Player.Jump;
        plungeAction = inputManager.Player.Plunge;
    }

    public void Start() {

        // Initialize states
        playerIdle = new PlayerIdle();
        playerMove = new PlayerMove();
        playerJump = new PlayerJump();
        playerPlunge = new PlayerPlunge();

        currentState = playerIdle;
        currentState.Enter();

    }

    public void Update() {
        Debug.Log(currentState);
        currentState.Update();

        Move();
        // UpdateAnimation();
        UpdateDir();
    }

    public void OnEnable() {
        inputManager.Player.Enable();
        jumpAction.Enable();
        jumpAction.performed += Jump;
    }

    public void OnDisable() {
        inputManager.Player.Disable();
        jumpAction.Disable();
    }

    public void transitionState(PlayerBaseState toState) {
        if(toState != currentState) {
            currentState.Exit();
            currentState = toState;
            toState.Enter();
        }
    }

    void Move() {
        rb.velocity = new Vector2(inputManager.Player.Move.ReadValue<Vector2>().x * playerSpeed, rb.velocity.y);
    }

    void Jump(InputAction.CallbackContext ctx) {
        transitionState(playerJump);
    }

    void UpdateDir() {
        if(rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Plunge(InputAction.CallbackContext ctx) {
        transitionState(playerPlunge);
    }

    internal void enablePlunge(bool b) {
        if(b) {
            plungeAction.Enable();
            plungeAction.performed += Plunge;
        }
        else {
            plungeAction.Disable();
            plungeAction.performed -= Plunge;
        }
    }
}
