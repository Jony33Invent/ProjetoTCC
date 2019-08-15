using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialogue dialog;

	public void TriggerDialogue(){
		FindObjectOfType<DialogManager>().StartDialogue(dialog);
	}

  	public void OnTriggerEnter2D(Collider2D other) {

		//Chama o diálogo quando detecta colisão com o player
         if(other.gameObject.name == "Player")
         	{
         		TriggerDialogue();
    			Destroy(gameObject);
    		}
    		
     }
}
