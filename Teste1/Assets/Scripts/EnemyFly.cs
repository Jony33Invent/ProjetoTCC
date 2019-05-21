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
    public float enemyLife;
    public SoundManage snd;
    public Animator an;
    public bool noChao;
    public float chaoY=-0.7F;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(enemyLife <= 0)
        {
            Destroy(gameObject);
        }

    	if((player.transform.position.x>transform.position.x && !viradoDireita) || (player.transform.position.x<transform.position.x && viradoDireita))
            Flip();


        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if(transform.position==new Vector3(transform.position.x, chaoY, 0f))
            noChao=true;

        if(playerInRange)
        {
            noChao = false;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            an.SetBool("isFollowingPlayer", true);
                return;
        
     	}
     	else
     	{

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, chaoY, 0f) , (moveSpeed/2) * Time.deltaTime);
            if(noChao)
                an.SetBool("isFollowingPlayer", false);
            return;
     	}

    }

    void OnTriggerEnter2D(Collider2D hitInfo){


        if(hitInfo.name=="Bullet(Clone)" && enemyLife>0)        
        {       
            MoveBullet scrptBullet= hitInfo.GetComponent<MoveBullet >();
            enemyLife-=scrptBullet.damage;
            Debug.Log(enemyLife);
            snd.PlaySound("hit");
        }
    }

    //private void OnDrawGizmos(){Gizmos.DrawSphere(transform.position, playerRange);}
    private void Flip(){
        viradoDireita = !viradoDireita;
        transform.Rotate(0f,180f,0f);
     }
}
