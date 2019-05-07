using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialogue dialog;
	public void TriggerDialogue(){
		FindObjectOfType<DialogManager>().StartDialogue(dialog);
	}
}
