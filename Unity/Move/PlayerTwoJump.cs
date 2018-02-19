using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTwoJump : MonoBehaviour 
{
    public enum JumpState
    {
        None, One, Two
    }

    [HideInInspector]
    public bool isJump = false;

    [HideInInspector]
    public bool isTwoStageJump = false;

    [HideInInspector]
    public bool isGrounded = false;

    public LayerMask groundLayer;
    public Transform groundStart;
    public Transform groundEnd;
    public float jumpForce = 360f;

    private new Rigidbody2D rigidbody2D;
    private JumpState state = JumpState.None;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (groundStart == null) groundStart = transform.Find("groundStart");
        if (groundEnd == null) groundEnd = transform.Find("groundEnd");
    }

    private void Update()
    {
        //从对象发射一条射线到 groundCheck 位置，是否碰撞到 groundLayer
        isGrounded = Physics2D.Linecast(groundStart.position, groundEnd.position, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJump = true;
        }
        else if (Input.GetButtonDown("Jump") && state == JumpState.Two)
        {
            isTwoStageJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            Jump();
        }
        if (state == JumpState.One && rigidbody2D.velocity.y < -0.05f)
        {
            state = JumpState.Two;
        }
        if (isTwoStageJump)
        {
            TwoStageJump();
        }
    }

    private void Jump()
    {
        state = JumpState.One;

        rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        isJump = false;
    }

    private void TwoStageJump()
    {
        state = JumpState.None;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        isTwoStageJump = false;
    }
}