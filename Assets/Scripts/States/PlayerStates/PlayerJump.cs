using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : PlayerBaseState
{
    private bool isFalling;

    private void Plunge(InputAction.CallbackContext ctx) {
        PlayerController.instance.transitionState(PlayerController.instance.playerPlunge);
    }

    public override void Enter()
    {
        isFalling = false;
        animator.Play("PlayerJump");
        rb.velocity = new Vector2(rb.velocity.x, PlayerController.instance.jumpSpeed);
        
        // Enable plunge
        inputManager.Player.Plunge.Enable();
        inputManager.Player.Plunge.performed += Plunge;
    }

    public override void Update()
    {
        if(rb.velocity.y <= 0) {
            animator.Play("PlayerFall");
            isFalling = true;
        }

        if(isFalling && rb.velocity.y == 0) {
            PlayerController.instance.transitionState(PlayerController.instance.playerIdle);
        }
    }

    public override void Exit()
    {
        inputManager.Player.Plunge.Disable();
        inputManager.Player.Plunge.performed -= Plunge;
    }
}
