using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerJump : MonoBehaviour
{
    [HideInInspector]
    public bool isJump = false;

    [HideInInspector]
    public bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpForce = 360f;
    public Action jumpEvent;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (groundCheck == null) groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        //从对象发射一条射线到 groundCheck 位置，是否碰撞到 groundLayer
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
            isJump = true;
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            if (jumpEvent != null)
                jumpEvent();
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            isJump = false;
        }
    }
}