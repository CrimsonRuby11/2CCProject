using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;

    [SerializeField]
    private float playerSpeed, jumpSpeed;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Rigidbody2D rb;

    private InputAction jumpAction;

    public void Awake() {
        inputManager = new InputManager();
        jumpAction = inputManager.Player.Jump;
    }

    public void Start() {
    }

    public void Update() {
        Move();
        UpdateAnimation();
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

    void Move() {
        rb.velocity = new Vector2(inputManager.Player.Move.ReadValue<Vector2>().x * playerSpeed, rb.velocity.y);
    }

    void Jump(InputAction.CallbackContext ctx) {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void UpdateAnimation() {
        if(rb.velocity.x != 0) {
            playerAnimator.SetBool("Moving", true);
        } else {
            playerAnimator.SetBool("Moving", false);
        }
    }

    void UpdateDir() {
        if(rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
