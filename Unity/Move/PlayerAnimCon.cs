using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCon : MonoBehaviour 
{
    private Animator anim;
    private new Rigidbody2D rigidbody2D;

    public Vector2 ve;

	private void Awake()
	{
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

	}

    private void Update()
    {
        ve = rigidbody2D.velocity;
        if(rigidbody2D.velocity.y !=0)
        {
            anim.SetBool("jump",true);
            anim.SetBool("idle",false);
            anim.SetBool("run", false);
        }else if(rigidbody2D.velocity.x != 0)
        {
            anim.SetBool("run",true);
            anim.SetBool("idle",false);
            anim.SetBool("jump", false);
        }
        else if (rigidbody2D.velocity == Vector2.zero)
        {
            anim.SetBool("jump", false);
            anim.SetBool("idle", true);
            anim.SetBool("run", false);
        }
    }
}