using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletChaveta : MonoBehaviour
{
	public float speed = 0f;
    public float damage = 10f;
	public Rigidbody2D rb;
    public float maxDistance=20f;

    public Transform bulletTr;
    private float initialX;
    private float atualX;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;


        bulletTr = GetComponent<Transform>();
        initialX = bulletTr.position.x;
    }
    
    void Update(){
        bulletTr = GetComponent<Transform>();
        atualX = bulletTr.position.x;
        if(Mathf.Abs(initialX)>Mathf.Abs(atualX)){
            if(Mathf.Abs(initialX) - Mathf.Abs(atualX)>=maxDistance)
            Destroy(gameObject);
        }
        else if(Mathf.Abs(initialX)<Mathf.Abs(atualX)){
          if(Mathf.Abs(atualX) - Mathf.Abs(initialX)>=maxDistance)
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.transform.tag!="Enemy" && hitInfo.transform.tag!="colTrigger"){
    	Destroy(gameObject);
        }   
    }
}
