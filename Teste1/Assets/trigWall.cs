using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trigWall : MonoBehaviour
{

public Transform parede;
public PlayerController plScript;
	 void OnTriggerEnter2D(Collider2D hitInfo){

    	//Verificar se o player esta no raio de colisão
        if(hitInfo.name=="Player"){
        	plScript.checkPoint = new Vector2(transform.position.x, 0f);
           parede.localPosition = new Vector3(parede.position.x, 4f, parede.position.z);
            Destroy(this.gameObject); 
        }   
    }

}
