using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssault : MonoBehaviour
{
	public bool deBoa = true;
	private bool viradoDireita = false;
	private float velocidade = -2;
	public float tempo = 3f;

    private PlayerController player;
    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInRange;

    public float JumpForce;
    public Rigidbody2D enemyBody;
    public bool noChao;
    public float enemyLife;
    public float speedDif = 2f;

    public Animator an;
    public float damage=10f;
    public SoundManage snd;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
		enemyBody = GetComponent<Rigidbody2D>();
		noChao = true;
		enemyLife = 10f;
    }

    // Update is called once per frame
    void Update()
    {
    	playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
    	

		enemyBody.velocity = new Vector2(velocidade, enemyBody.velocity.y);
		tempo -= Time.deltaTime;
		if(tempo <= 0 && deBoa)
		{
			flip();
		}
		if(enemyLife <= 0)
		{
			Destroy(gameObject);
		}

    	if(playerInRange){

    		if(deBoa==true){
				an.SetBool("isFollowingPlayer", true);
    			SeguirPlayer();
    		}

			if((player.transform.position.x > transform.position.x && !viradoDireita) || (player.transform.position.x < transform.position.x && viradoDireita) && (player.transform.position.y <= transform.position.y))
			{
				
				flip();
			}
    	}
    	else if(deBoa == false){
			an.SetBool("isFollowingPlayer", false);
    		DeixarPlayer();
    	}
	}

	private void flip()
	{
		velocidade = velocidade * -1;
		GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
		viradoDireita = !viradoDireita;
		tempo = 3;
	}

	

	void SeguirPlayer()
	{
			velocidade=velocidade*speedDif;
			deBoa = false;
			if(noChao)
			{
				enemyBody.AddForce(new Vector2(0f, JumpForce));

				//Debug.Log("PULOU NO MEU PENIS");
			}	
			noChao = false;
	}

	void DeixarPlayer()
	{
			velocidade=velocidade/speedDif;
			deBoa = true;
			flip();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Floor"))
		{
			noChao = true;

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
}