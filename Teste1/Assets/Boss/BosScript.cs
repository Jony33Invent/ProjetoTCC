using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosScript : MonoBehaviour
{	public DialogManager dialog;
	private bool boleanointerno;
	private int atac;
    public float timeMAX;
    private float timer;
    private float timerBala;
    public Transform trBala;
    public GameObject bala;
    public GameObject fogo1;
    public GameObject fogo2;
    public GameObject fogo3;
    public bool viradoDireita = true;
    public Transform trPlayer;
    public Transform trBoss;
    public bool seguirPlayer;
    public bool atirar;
    public float moveSpeed;
    public float damage;
    public Animator an;
    public Dialogue question_dialog;
    public float BossLife;
    // Start is called before the first frame update
    void Start()
    {
        boleanointerno=dialog.BossAtaca;
        timer = 0.5f;
        atac = 0;
        atirar=false;
    }

    // Update is called once per frame
    void Update()
    {
               
        if((trPlayer.position.x>trBoss.position.x && !viradoDireita) || (trPlayer.position.x<trBoss.position.x && viradoDireita))
            Flip();

     	if(!boleanointerno){
     		boleanointerno = dialog.BossAtaca;
     	}
     	else{
     		 if(timer<=0)
                    {
    				fogo1.SetActive(false);
    				fogo2.SetActive(false);
    				fogo3.SetActive(false);
    				seguirPlayer=false;
                    atirar=false;
                     	timer=timeMAX;
                       	//gerador de ataque aleatorio
					   	//atac=Random.Range(0, 3);
					   	switch(atac){
					   		case 0:
                            case 2:

                            atirar=true;
                                //an.Play("Atac1Animation");
					   		break;
					   		case 1:
                                an.Play("Atac2Animation");
					   		break;
                            case 3:
                                an.Play("Atac3Animation");
					   		break;
                            case 4:
                                TrigDialog();
                            break;
					   	}
                        atac++;
                    if(atac>5)
                        atac=0;
                    }
                    else {
                        timer-=Time.deltaTime;
                        if(atirar){
                            if(timerBala <=0){
                                timerBala=timeMAX/5;
                                an.Play("Atac1Animation");
                            }
                            else
                            timerBala-=Time.deltaTime;
                        }
                    }    

     	}
     	if(seguirPlayer){
     		transform.position = Vector3.MoveTowards(trBoss.position, new Vector3(trPlayer.position.x, trBoss.position.y, trBoss.position.z), moveSpeed * Time.deltaTime);
     	}
     	else{

        if((111.02f>trBoss.position.x && !viradoDireita) || (111.02f<trBoss.position.x && viradoDireita))
            Flip();

     		transform.position = Vector3.MoveTowards(trBoss.position, new Vector3(111.02f, 0.41f, 0f), moveSpeed * Time.deltaTime);
     	}
    }

    void Ataque1(){
        Instantiate(bala, trBala.position, trBala.rotation);
    }

    void Ataque2(){
    			fogo2.SetActive(true);
    			fogo3.SetActive(true);
    	seguirPlayer=true;
    }

    void Ataque3(){

        //ATAQUE BASEADO NA POSIÇÃO DO PLAYER
            if(trPlayer.position.y < 2f)
                fogo1.SetActive(true);
            else if(trPlayer.position.y > 2f && trPlayer.position.y < 4f)
               fogo2.SetActive(true);
            else
                fogo3.SetActive(true);

    //    if(atac == 3)
    //    {
    //        fogo1.SetActive(true);
    //    }
    //    else if(atac == 4){
    //        fogo1.SetActive(true);
    //        fogo2.SetActive(true);
    //        }
    //    else{
    //     fogo1.SetActive(true);
    //      fogo3.SetActive(true);
    //    }


    }
    void TrigDialog(){
        FindObjectOfType<DialogManager>().StartDialogue(question_dialog);
       
    }

     void OnTriggerEnter2D(Collider2D hitInfo){
        if(BossLife>0){
            if(hitInfo.name=="Bullet(Clone)"){      
                MoveBullet scrptBullet= hitInfo.GetComponent<MoveBullet >();
                BossLife-=scrptBullet.damage;
                Debug.Log("Vida do Chefe: "+BossLife);
            }
        }else{
            Destroy(this.gameObject); 
        }
    }
    private void Flip(){
        viradoDireita = !viradoDireita;
        trBoss.Rotate(0f,180f,0f);
     }
}
