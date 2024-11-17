using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerBaseState
{
    public override void enter()
    {
        base.enter();

        animator.Play("PlayerIdle");
        rb.velocity = new Vector2(0, 0);

        // Animation
    }

    public override void update() {
        base.update();

        if(inputManager.Player.Move.ReadValue<Vector2>().x != 0) {
            PlayerController.instance.transitionState(PlayerController.instance.playerRun);
        }
    }
}
