using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : PlayerBaseState
{
    Vector2 input;

    public override void enter()
    {
        base.enter();

        // Animation
        animator.Play("PlayerRun");

        input = inputManager.Player.Move.ReadValue<Vector2>();
        if(input.x > 0) {
            PlayerController.instance.flipSprite(false);
        } else PlayerController.instance.flipSprite(true);
    }

    public override void update()
    {
        base.update();

        rb.velocity = new (input.x * PlayerController.instance.playerSpeed, rb.velocity.y);
        if(inputManager.Player.Move.ReadValue<Vector2>().x == 0) {
            PlayerController.instance.transitionState(PlayerController.instance.playerIdle);
        }
    }
}
