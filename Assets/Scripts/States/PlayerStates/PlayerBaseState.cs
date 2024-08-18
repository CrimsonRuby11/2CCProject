using UnityEngine;

public class PlayerBaseState : IState
{
    protected Rigidbody2D rb;
    protected InputManager inputManager;
    protected Animator animator;

    public PlayerBaseState() {
        rb = PlayerController.instance.rb;
        inputManager = PlayerController.instance.inputManager;
        animator = PlayerController.instance.playerAnimator;
    }

    public virtual void Enter() {

    }

    public virtual void Update() {

    }

    public virtual void Exit() {

    }

    public virtual void FixedUpdate() {

    }
}
