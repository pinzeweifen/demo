﻿using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour 
{
    [HideInInspector]
    public bool isRight = true;
    public float moveForce = 100f;
    public float maxSpeed = 2f;
    public Action<bool> onMove;

    private float horizontal;
    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
   
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        if(horizontal>0&& !isRight)
        {
            Flip();
        }
        else if (horizontal<0 && isRight)
        {
            Flip();
        }

        if (horizontal * rigidbody2D.velocity.x < maxSpeed)
        {
            Move(horizontal);
        }
        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x)* maxSpeed, rigidbody2D.velocity.y);
        }
        if(rigidbody2D.velocity.x >-0.005f && rigidbody2D.velocity.x < 0.005f)
        {
            if (onMove != null)
                onMove(false);
        }
    }

    void Flip()
    {
        isRight = !isRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Move(float h)
    {
        
        rigidbody2D.AddForce(Vector2.right * h * moveForce);
        if(rigidbody2D.velocity.x > 0.005f|| rigidbody2D.velocity.x < -0.005f)
        {
            if (onMove != null)
                onMove(true);
        }
    }
}