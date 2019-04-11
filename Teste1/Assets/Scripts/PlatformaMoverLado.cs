using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMoverLado : MonoBehaviour
{ 
	public float speed;
	private Rigidbody2D rb;
	public float minX;
	public float maxX;
	public Transform trPlatform;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		trPlatform = GetComponent<Transform>();
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void FixedUpdate()
	{
		//trPlatform = this.transform;
		if(trPlatform.position.x <= minX )
			rb.velocity = new Vector2(speed, rb.velocity.y);
		else if(trPlatform.position.x >=maxX)
			rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
}
