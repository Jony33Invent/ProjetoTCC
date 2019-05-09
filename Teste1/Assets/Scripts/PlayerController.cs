using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variáveis  

    [Header("Player")]
    public Rigidbody2D body;
    public SpriteRenderer sprite;
    public Transform trPlayer;
    public float playerHealth;
    public float initialHealth;




    [Header("Attack")]
    public Transform AttackCheck;
    public float radiusAttack;
    public LayerMask layerEnemy;
    public float damage = 20f;
    float TimeNextAttack=0.5f;

    [Header("Shoot")]
    public Transform trBala;
    public GameObject bala;
    float TimeNextShoot;
    public float maxTimeShooting = 0.5f;

    [Header("Movement")]
    public Animator anim;
    public bool viradoDireita = true;
    public float speed = 5f;
    public float JumpForce = 100f;
    bool isOnFloor = false;
    //bool isOnWall = false; 
    bool isJumping = false;
    float move;
    public Transform GroundCheck;
    public LayerMask whatIsGround;
    //public LayerMask whatIsWall;

    [Header("Others")]
    public int qtdMoedas=0;
    float radius = 0.35f;
    int results;
    public GameObject menu;
    private SoundManage snd;
    public float TimeNextTeleport;

    //float range = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerHealth=initialHealth;
        TimeNextShoot=maxTimeShooting;
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        trPlayer = GetComponent<Transform>();
        snd = GetComponent<SoundManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth<=0){
                    trPlayer.position = new Vector2(0f,0f);
                    Debug.Log("Morreu");
                    playerHealth=initialHealth;
                    snd.PlaySound("death");
                }

        // Para detectar o chão
        isOnFloor = Physics2D.Linecast(transform.position, GroundCheck.position, whatIsGround);
		//isOnWall = Physics2D.Linecast(transform.position, trBala.position, whatIsWall);
   
        // If para executar a ação de pulo
        if(isOnFloor == true)
        	if (Input.GetButtonDown("Jump"))
        	{
            	isJumping = true;

            snd.PlaySound("jump");
       		}



    }
    private void FixedUpdate()
    {
        // Variável para mover o personagem
         move = Input.GetAxis("Horizontal");



        // Movimentar o personagem horizontalmente beaseado velocidade de movimento declarada anteriormente 
        //if(!isOnWall)
        body.velocity = new Vector2(move * speed, body.velocity.y);


        // If para inverter a posição do personagem
        if (move > 0 && !viradoDireita || (move <0 && viradoDireita))
        {
            Flip();       
        }

        // If que adiciona uma força de pulo no personagem
        if(isJumping)
        {
            body.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;

        }

        //Chama o menu ao apertar o botão
        if(Input.GetButtonDown("Fire3")){
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            } 
        }
    	//Execução da animação de attack
       	if (TimeNextAttack <= 0)
        {
            if(Input.GetButtonDown("Fire1") && body.velocity == new Vector2(0, 0)) {
            anim.SetBool("isAttacking", true);
            TimeNextAttack = 0.5f;
            //PlayerAttack();

            }
        }
        else{
            TimeNextAttack -= Time.deltaTime;
            if(TimeNextShoot<=0.1f)
            anim.SetBool("isAttacking", false);
        }

        //Execução da animação de tiro
        if(TimeNextShoot<=0 && Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("isShooting",true);
            TimeNextShoot=maxTimeShooting;
            //Shoot();
        }
        else {
            TimeNextShoot-=Time.deltaTime;
            if(TimeNextShoot<=maxTimeShooting-0.1f)
            anim.SetBool("isShooting",false);

        }
            
        SetAnimation();
    }

    
    private void SetAnimation(){

		//Animação de Movimento
        if(move!=0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        //Animação de Pulo
     	//if(isOnFloor)
        	//{
            	//anim.SetBool("isJumping", false);
        	//}else
            	//anim.SetBool("isJumping", true);

    }

    //Função do tiro
    private void Shoot(){
        Instantiate(bala, trBala.position, trBala.rotation);
    }

    //Função de virada do personagem
    public void Flip(){
        viradoDireita = !viradoDireita;
        trPlayer.Rotate(0f,180f,0f);
     }

    //Função do ataque
    void Attack()
    {
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(AttackCheck.position, radiusAttack, layerEnemy);
        for (int i = 0; i < enemiesAttack.Length; i++)
        {
            Debug.Log("Ataque: " + enemiesAttack[i].name);

            if (enemiesAttack[i].name == "chaveta")
            {
                GameObject enemiesGO = enemiesAttack[i].gameObject;
                EnemyHit scrptEnemy = enemiesGO.GetComponent<EnemyHit>();
                Transform trEnemy = enemiesGO.GetComponent<Transform>();
            	trEnemy.localScale= new Vector3(trEnemy.localScale.x-0.02f, trEnemy.localScale.y-0.02f, trEnemy.localScale.z);
                scrptEnemy.health -= damage;
                Debug.Log("Vida: " + scrptEnemy.health);
                //if(scrptEnemy.health == 0)
                //{
                    //Destroy(canvas);
                //}


            }
            
        }
    }


    //Função para desenhar um circulo em volta do objeto GroundCheck (só pra ajudar na visualização)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GroundCheck.position, radius);
    }

}

