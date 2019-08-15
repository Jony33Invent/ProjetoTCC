using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public PlayerController plScript;
	public MoveBulletChaveta scrptBullet;
	public Animator anim;
    public SoundManage snd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "EnemyFly")
        {
            EnemyFly scrpt = hitInfo.GetComponent<EnemyFly>();
            plScript.playerHealth -= scrpt.damage;
            Dano(hitInfo);
        }
        else if(hitInfo.name == "EnemyAssault")
         {
            EnemyAssault scrpt = hitInfo.GetComponent<EnemyAssault>();
            plScript.playerHealth-=scrpt.damage;
            Dano(hitInfo);
         }
         else if(hitInfo.name == "Boss"){
            BosScript scrpt = hitInfo.GetComponent<BosScript>();
            plScript.playerHealth-=scrpt.damage;
            Dano(hitInfo);
         }
         else if(hitInfo.name == "fogo1"){
            plScript.playerHealth-=7f;
            Dano(hitInfo);
         }

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.name=="BulletChaveta(Clone)" || hitInfo.name=="BulletStudent(Clone)")
        {
        	MoveBulletChaveta scrpt= hitInfo.GetComponent<MoveBulletChaveta>();  
            plScript.playerHealth-=scrpt.damage;
            Dano(hitInfo);
        }
            
    }
        void Dano(Collider2D hitInfo){
            if(plScript.playerHealth%100 == 0)
        	  { //snd.PlaySound("hit");

                if(hitInfo.transform.rotation.y == -1)
            	{
            		if(plScript.viradoDireita)
            		anim.Play("Damage");
            		else
            		{
            			plScript.Flip();
            			anim.Play("Damage");

            		}
            	}
            	else{
            		if(!plScript.viradoDireita)
            		anim.Play("Damage");
            		else
            		{
            			plScript.Flip();
            			anim.Play("Damage");

            		}
            	}
            }
            //Debug.Log("Vida do Player: "+plScript.playerHealth);
        }
}






