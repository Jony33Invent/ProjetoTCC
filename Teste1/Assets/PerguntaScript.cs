using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class PerguntaScript : MonoBehaviour
{
	public Pergunta[] perg;

	public TextMeshProUGUI pergunText;
	public TextMeshProUGUI alternText1, alternText2, alternText3, alternText4;
    public GameObject canvasPergunta;
    public Dialogue dialog_erro, dialog_acert;
    public GameObject boss;
	int rnd;
    // Start is called before the first frame update
    void OnEnable()
    {
    	rnd = Random.Range(0, perg.Length);
    	pergunText.text=perg[rnd].pergunta;

    //random shuffle
      for (int i = 0; i < perg[rnd].alternativas.Length; i++) {
         string temp = perg[rnd].alternativas[i];
         int randomIndex = Random.Range(i, perg[rnd].alternativas.Length);
         perg[rnd].alternativas[i] = perg[rnd].alternativas[randomIndex];
         perg[rnd].alternativas[randomIndex] = temp;
     }	
        alternText1.text=perg[rnd].alternativas[0];
        alternText2.text=perg[rnd].alternativas[1];
        alternText3.text=perg[rnd].alternativas[2];
        alternText4.text=perg[rnd].alternativas[3];
    }

    public void altBtnClick(int n){
    	if(perg[rnd].alternativas[n]==perg[rnd].resposta){
    		Debug.Log("ACERTOU");
        	FindObjectOfType<DialogManager>().StartDialogue(dialog_acert);
        	BosScript scrpt= boss.GetComponent<BosScript>();
        	scrpt.BossLife-=200f;
    	}
    	else{
    		Debug.Log("ERROU");
        	FindObjectOfType<DialogManager>().StartDialogue(dialog_erro);

    	}

        canvasPergunta.SetActive(false);
        Time.timeScale = 1;
    }
}
