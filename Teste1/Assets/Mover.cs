using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator an;
    [Range(0, 5f)]public float speed;
    private float horizontalMove = 0;

	private Vector3 movVel = Vector3.zero;

    [Range(0, .3f)] [SerializeField] private float movSmooth = .05f;
	[SerializeField] private float jumpForce = 400f;	
    private bool FacingRight = true;  

    void Awake(){
    	rb = GetComponent<Rigidbody2D>();
    	an = GetComponent<Animator>();
    }

    void Update(){

    	horizontalMove = Input.GetAxisRaw("Horizontal")*speed;

    }
   

 	void FixedUpdate()
    {
    	Move(horizontalMove);
    	if(horizontalMove!=0)
		an.SetBool("isMoving",true);
		else
		an.SetBool("isMoving",false);
    }


   	private void Move(float move)
	{
			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref movVel, movSmooth);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
	}

	private void Jump(){

			rb.AddForce(new Vector2(0f, jumpForce));
	}

	private void Flip()
	{
		FacingRight = !FacingRight;

		Vector3 auxScale = transform.localScale;
		auxScale.x *= -1;
		transform.localScale = auxScale;
	}
}
