using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour

    

{
    private PlayerController player;
    public float moveSpeed;
    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInRange;
    public bool fancingAway;
    public float damage;
    public bool viradoDireita = true;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {   

    	if((player.transform.position.x>transform.position.x && !viradoDireita) || (player.transform.position.x<transform.position.x && viradoDireita))
            Flip();


        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        
        if(playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                return;
        
     	}
     	else
     	{

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -0.5f, 0f) , moveSpeed * Time.deltaTime);
                return;
     	}

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, playerRange);

    }
    private void Flip(){
        viradoDireita = !viradoDireita;
        transform.Rotate(0f,180f,0f);
     }
}
