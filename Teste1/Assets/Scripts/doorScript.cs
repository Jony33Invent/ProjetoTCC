using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
	public Animator anDoor;
	public float newX;
	public float newY;
	public PlayerController plScript;
    public float tm;
    public float maxTimeTeleport = 5f;
	float move;
	public Transform playerTransform;
    public PlayerController plscript;
	public Dialogue dialog;
	public void TriggerDialogue(){
		FindObjectOfType<DialogManager>().StartDialogue(dialog);
	}
    // Start is called before the first frame update
    void Start()
    {
        	plScript.TimeNextTeleport=maxTimeTeleport;
    }

    // Update is called once per frame
    void Update()
    {

    	move = Input.GetAxis("Vertical");
        if(plScript.TimeNextTeleport<=0 && move > 0 && anDoor.GetBool("isOpen")==true && plscript.enemyAlive<=0){
        	
        	plScript.TimeNextTeleport=maxTimeTeleport;
        	TeleportarPlayer(newX, newY);
        }
        else{
        	plScript.TimeNextTeleport-=Time.deltaTime;

        }

    }

	void OnTriggerStay2D(Collider2D hitInfo){
			if(hitInfo.name=="Player" && plscript.enemyAlive>0 && move>0)
				TriggerDialogue();
		}

    void OnTriggerEnter2D(Collider2D hitInfo){

    	//Verificar se o player esta no raio de colisão
        if(hitInfo.name=="Player" && plscript.enemyAlive<=0){
            anDoor.SetBool("isOpen",true);

        }   
    }
    void OnTriggerExit2D(Collider2D hitInfo){

    	//Verificar se o player esta no raio de colisão
        if(hitInfo.name=="Player" && plscript.enemyAlive<=0){
            anDoor.SetBool("isOpen",false);
        }   
    }

    void TeleportarPlayer(float x, float y){
    	//Aqui vai a bagaça
    	playerTransform.localPosition = new Vector3(x, y, 0);
    }

}
