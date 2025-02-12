﻿using System.Collections;
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
    public int tirosPorTroca = 10;
    public Animator anim;
    public SoundManage snd;
    public PlayerController plscript;
    private bool mudou;

    void Start(){
        timer=timeMAX;
        anim = GetComponent<Animator>();
        mudou=false;
    }
    
    void Update()
    {
        if((trPlayer.position.x>trChaveta.position.x && !viradoDireita) || (trPlayer.position.x<trChaveta.position.x && viradoDireita))
            Flip();
        
        if(eleMorre){
            if(health<=0)
            Destroy(this.gameObject); 
              if(timer<=0)
                    {
                        timer=timeMAX;
                        Shoot();
                    }
                    else {
                        timer-=Time.deltaTime;
                    }
            }
            else{      
                if(qtdTirosLevados<tirosPorTroca*3){
                    if(timer<=0)
                    {
                        timer=timeMAX;
                        Shoot();
                    }
                    else {
                        timer-=Time.deltaTime;
                    }
                }
                else{
                    if(!mudou)
                        plscript.enemyAlive--;

                    mudou=true;
                }
            }
    }
      void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.name=="Bullet(Clone)" && health>0){
            qtdTirosLevados++;
            if((qtdTirosLevados%tirosPorTroca) == 0){
                if(!eleMorre)
                anim.SetInteger("anState", qtdTirosLevados/tirosPorTroca);
            }
            Diminuir();

            
        	MoveBullet scrptBullet= hitInfo.GetComponent<MoveBullet >();
        	health-=scrptBullet.damage;
            snd.PlaySound("hit");
            //Debug.Log("Vida do Chaveta: "+health);
        }

    }
    private void Diminuir(){
        trChaveta.localScale= new Vector3(trChaveta.localScale.x-qtdDiminui, trChaveta.localScale.y-qtdDiminui, trChaveta.localScale.z);

    }

    private void Shoot(){
        Instantiate(bala, trBala.position, trBala.rotation);
    }

    private void Flip(){
        viradoDireita = !viradoDireita;
        trChaveta.Rotate(0f,180f,0f);
     }
}
