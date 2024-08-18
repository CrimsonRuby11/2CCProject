using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerBaseState
{
    public override void Enter()
    {
        animator.Play("PlayerMove");
    }

    public override void Update()
    {
        if(inputManager.Player.Move.ReadValue<Vector2>().x == 0) {
            PlayerController.instance.transitionState(PlayerController.instance.playerIdle);
        }
    }
}
