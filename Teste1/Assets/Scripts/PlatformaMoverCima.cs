using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMoverCima : MonoBehaviour
{ 
	public float speed;
	private Rigidbody2D rb;
	public float minY; //y 4
	public float maxY; //y 11
	public Transform trPlatform;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		trPlatform = GetComponent<Transform>();
		rb.velocity = new Vector2(rb.velocity.x, speed);
	}

	void FixedUpdate()
	{
		//trPlatform = this.transform;
		if(trPlatform.position.y <= minY )
			rb.velocity = new Vector2(rb.velocity.x, speed);
		else if(trPlatform.position.y >=maxY)
			rb.velocity = new Vector2(rb.velocity.x,-speed);
    }
}
