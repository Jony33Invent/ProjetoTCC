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
    public float timeMAX;
    private float timer;
    public bool BossAtaca;
    public GameObject canvasPergunta;
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
    	BossAtaca = false;
        falas = new Queue<string>();
        timer = timeMAX;
    }
    void Update(){

    	//Fala automática
    	AutomaticDisplayNext();
    }
    public void StartDialogue(Dialogue dialog){
		if(nameText.text=="Professor Olavo" || nameText.text=="Professor Olavo Meio Triste"){
			BossAtaca = false;
		}
    	//animator.SetBool("isOpen",true);
    	nameText.text=dialog.name;
   		falas.Clear();
	   	foreach(string fala in dialog.falas){
	   		falas.Enqueue(fala);
	   	}
	   	animator.SetBool("isOpen",true);
   		DisplayNextFala();

    }

	public void DisplayNextFala(){
		if(falas.Count>0){
			if(falas.Count == 1){
				EndDialogue();
				return;	
			}

		string fala = falas.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(fala));
		}
	}
	IEnumerator TypeSentence(string fala){
		dialogueText.text = "";
		foreach(char letra in fala.ToCharArray()){
			dialogueText.text += letra;
			yield return null;
		}
	}
	void EndDialogue(){
			string fala = falas.Dequeue();
			StopAllCoroutines();
			StartCoroutine(TypeSentence(fala));
			animator.SetBool("isOpen",false);

		if(nameText.text=="Professor Olavo"){
			BossAtaca = true;
		}else if(nameText.text=="Professor Olavo Pistola"){
			if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvasPergunta.SetActive(true);
            } 
		}else if(nameText.text=="Professor Olavo Meio Triste"){
			  Destroy(boss);		
			}
	}

	void AutomaticDisplayNext(){
    	 if(timer<=0)
            {
                timer=timeMAX;
                DisplayNextFala();
            }
            else {
                timer-=Time.deltaTime;
            }
	}
}
