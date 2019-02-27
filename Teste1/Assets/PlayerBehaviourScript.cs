using System.Collections;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    private Animator an;
    private Transform tr;
    private Rigidbody2D rb2D;

    public Transform verifyFloor;
    public Transform verifyWall;

    private bool isOnFloor;
    private bool isMoving;
    private bool isOnWall;
    private bool isJumping;
    private bool isTurnedRight;

    private float axis;
    public float radiusValFloor;
    public float radiusValWall;
    public float velocity;
    public float jumpForce;

    public LayerMask solid;


    // Start is called before the first frame update
    void Start()
    {
 		an = GetComponent<Animator> ();
 		tr = GetComponent<Transform> ();
 		rb2D = GetComponent<Rigidbody2D> ();
		
		isTurnedRight = isOnFloor = true;
		isMoving = isOnWall = false;

    }

    // Update is called once per frame
    void Update()
    {
    	isOnFloor = Physics2D.OverlapCircle(verifyFloor.position, radiusValFloor, solid);
    	isOnWall = Physics2D.OverlapCircle(verifyWall.position, radiusValWall, solid);
    	if(isOnFloor)
    		isJumping=false;
    	axis = Input.GetAxisRaw("Horizontal");
    	isMoving = Mathf.Abs(axis)>0f;

    	if(axis > 0f && !isTurnedRight)
    		Flip();
    	else if(axis < 0f && isTurnedRight)
			Flip();

		if(Input.GetKeyDown(KeyCode.W) && isOnFloor)
			isJumping = true;

			if(rb2D.velocity== new Vector2(0, rb2D.velocity.y))
    			an.SetBool("isMoving",false);
    }

    void FixedUpdate(){
    	if(isJumping && isOnFloor)
    		rb2D.AddForce(transform.up*jumpForce);

    	if(isMoving && isOnFloor){
    		if(isTurnedRight)
    			rb2D.velocity = new Vector2(velocity, rb2D.velocity.y);
    		else
    			rb2D.velocity = new Vector2(-velocity, rb2D.velocity.y);

    			an.SetBool("isMoving",true);
    	}
    }

    void Flip(){
    	isTurnedRight = !isTurnedRight;
    	tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
    }
}

