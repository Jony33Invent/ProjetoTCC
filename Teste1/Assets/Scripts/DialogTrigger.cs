using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialogue dialog;
	public void TriggerDialogue(){
		FindObjectOfType<DialogManager>().StartDialogue(dialog);
	}
  	void OnTriggerEnter2D(Collider2D other) {
         if(transform.parent && transform.parent.gameObject != other.gameObject && other.gameObject.name == "Player")
         	{
         		TriggerDialogue();
    			Destroy(gameObject);
    		}
     }

}
