using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public PlayerController plScript;
	public MoveBulletChaveta scrptBullet;
	public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }     

     void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.name=="BulletChaveta(Clone)" || hitInfo.name=="BulletStudent(Clone)"){
        	MoveBulletChaveta scrptBullet= hitInfo.GetComponent<MoveBulletChaveta>();
        	plScript.playerHealth-=scrptBullet.damage;
        	
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
            //Debug.Log("Vida do Player: "+plScript.playerHealth);
        }
    }
}
