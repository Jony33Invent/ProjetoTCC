using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
	public float health;
    public float timeMAX;
    private float timer;
    public Transform trPlayer;
    public Transform trChaveta;
    public Transform trBala;
    public GameObject bala;
    public bool viradoDireita = true;
    public bool eleMorre=true;
    public float qtdDiminui = 0.02f;
    private int qtdTirosLevados=0;
    public Animator anim;

    void Start(){
        timer=timeMAX;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if((trPlayer.position.x>trChaveta.position.x && !viradoDireita) || (trPlayer.position.x<trChaveta.position.x && viradoDireita))
            Flip();
        
        if(eleMorre && health<=0)
            Destroy(this.gameObject);       
        if(qtdTirosLevados<3){
            if(timer<=0)
            {
                timer=timeMAX;
                Shoot();
            }
            else {
                timer-=Time.deltaTime;
            }
        }
            
    }
      void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.name=="Bullet(Clone)" && health>0){
            qtdTirosLevados++;
            if(!eleMorre)
            anim.SetInteger("anState", qtdTirosLevados);
        	MoveBullet scrptBullet= hitInfo.GetComponent<MoveBullet >();
        	health-=scrptBullet.damage;
            trChaveta.localScale= new Vector3(trChaveta.localScale.x-qtdDiminui, trChaveta.localScale.y-qtdDiminui, trChaveta.localScale.z);
            //Debug.Log("Vida do Chaveta: "+health);
        }
    }

    private void Shoot(){
        Instantiate(bala, trBala.position, trBala.rotation);
    }

    private void Flip(){
        viradoDireita = !viradoDireita;
        trChaveta.Rotate(0f,180f,0f);
     }
}
