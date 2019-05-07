using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	private Queue<string> falas;
	public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        falas=new Queue<string>();
    }

    public void StartDialogue(Dialogue dialog){
    	animator.SetBool("isOpen",true);
    	nameText.text=dialog.name;
   		falas.Clear();
	   	foreach(string fala in dialog.falas){
	   		falas.Enqueue(fala);
	   	}
   		DisplayNextFala();

    }

	public void DisplayNextFala(){
		if(falas.Count == 0){
			EndDialogue();
			return;	
		}

		string fala = falas.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(fala));
	}
	IEnumerator TypeSentence(string fala){
		dialogueText.text = "";
		foreach(char letra in fala.ToCharArray()){
			dialogueText.text += letra;
			yield return null;
		}
	}
	void EndDialogue(){
		StopAllCoroutines();
		StartCoroutine(TypeSentence("Falous"));
		animator.SetBool("isOpen",false);
	}
}
