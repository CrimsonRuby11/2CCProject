using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlunge : PlayerBaseState
{
    public override void Enter()
    {
        // Set plunge speed
        rb.velocity = new Vector2(0, -PlayerController.instance.plungeSpeed);

        // Plunge animation
        animator.Play("PlayerPlunge");
    }

    public override void Update()
    {
        if(rb.velocity.y == 0) {
            PlayerController.instance.transitionState(PlayerController.instance.playerIdle);
        }
    }
}
