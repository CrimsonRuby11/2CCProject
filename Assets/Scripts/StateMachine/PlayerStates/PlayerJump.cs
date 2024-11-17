using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerBaseState
{
    bool isFalling = false;

    public override void enter()
    {
        base.enter();

        animator.Play("PlayerJump");

        rb.velocity = new Vector2(rb.velocity.x, PlayerController.instance.jumpSpeed);
    }

    public override void update()
    {
        base.update();

        rb.velocity = new Vector2(
            inputManager.Player.Move.ReadValue<Vector2>().x * PlayerController.instance.playerSpeed,
            rb.velocity.y
        );  

        if(rb.velocity.y < 0 && !isFalling) {
            animator.Play("PlayerFall");
        }

        if(rb.velocity.x >= 0) {
            PlayerController.instance.flipSprite(false);
        } else {
            PlayerController.instance.flipSprite(true);
        }

        if(rb.velocity.y >= -0.001 && rb.velocity.y <= 0.001) {
            PlayerController.instance.transitionState(PlayerController.instance.playerIdle);
        }
    }
}
