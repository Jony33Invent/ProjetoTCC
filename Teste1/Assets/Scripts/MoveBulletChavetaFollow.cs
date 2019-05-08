using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletChavetaFollow : MonoBehaviour
{
	public float speed = 0f;
    public float damage = 10f;
	public Rigidbody2D rb;
    public float maxDistance=20f;

    public Transform bulletTr;
    public Transform playerTr;
    private float initialX;
    private float atualX;
    private float i = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        playerTr = FindObjectOfType<PlayerController>().trPlayer;
        bulletTr = GetComponent<Transform>();

        //Define uma velocidade vertical e horizontal pro objeto baseado na posição do player
        if(playerTr.position.y > bulletTr.position.y){
        	if(playerTr.position.x > bulletTr.position.x)
        	rb.velocity =  new Vector2(speed, speed/2);
        	else
        	rb.velocity =  new Vector2(-speed, speed/2);
        }
        else{
        	if(playerTr.position.x > transform.position.x)
        	rb.velocity =  new Vector2(speed, -speed/10);
        	else
        	rb.velocity =  new Vector2(-speed, -speed/10);
        }

        initialX = bulletTr.position.x;
    }
    
    void Update(){
        bulletTr = GetComponent<Transform>();

    	//Girar o objeto
        bulletTr.rotation = Quaternion.AngleAxis(i, Vector3.back);
        i+=5;


        atualX = bulletTr.position.x;

        //Verificar se o objeto está no raio de distancia x maxima e destrui-lo caso nãos esteja
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

    	//Verificar se o objeto atingiu algo que não é o proprio atirador
        if(hitInfo.transform.tag!="Enemy" && hitInfo.transform.tag!="colTrigger" && hitInfo.transform.tag!="plBullet"){
    		Destroy(gameObject);
        }   
    }
}
