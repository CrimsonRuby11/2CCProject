using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected InputManager inputManager;
    protected Rigidbody2D rb;
    protected Animator animator;

    public PlayerBaseState() {
        inputManager = PlayerController.instance.inputManager;
        rb = PlayerController.instance.GetComponent<Rigidbody2D>();
        animator = PlayerController.instance.GetComponent<Animator>();
    }

    public virtual void enter()
    {
    }

    public virtual void exit()
    {
    }

    public virtual void update()
    {
    }
}
