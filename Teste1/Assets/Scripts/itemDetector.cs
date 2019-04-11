using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDetector : MonoBehaviour
{ 	public GameObject trof;
	public GameObject item_go;
	public GameObject player_go;
	public Transform player;
	public Transform item;
	private Transform newItemTransf;
	public PlayerController plyerScrpt;
	public float range=1;

    // Start is called before the first frame update
    void Start()
    {
           item = newItemTransf = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if((player.position.x < item.position.x+range && player.position.x > item.position.x-range) && (player.position.y < item.position.y+range && player.position.y > item.position.y-range))
        	{


                //Banco de posições para o item
                switch(Random.Range(0,11))
                {
                    case 0:
                    newItemTransf.position = new Vector3(0.9f, 2.5f, 0f);
                    break;

                    case 1:
                    newItemTransf.position = new Vector3(8.7f,7.2f,0f);
                    break;

                    case 2:
                    newItemTransf.position = new Vector3(24f,8f,0f);
                    break;

                    case 3:
                    newItemTransf.position = new Vector3(5f,9.5f,0f);
                    break;

                    case 4:
                    newItemTransf.position = new Vector3(37f,5.5f,0f);
                    break;

                    case 5:
                    newItemTransf.position = new Vector3(51.5f,13f,0f);
                    break;

                    case 6:
                    newItemTransf.position = new Vector3(62.4f,2.6f,0f);
                    break;

                    case 7:
                    newItemTransf.position = new Vector3(76.5f,5f,0f);
                    break;

                    case 8:
                    newItemTransf.position = new Vector3(55.7f,5f,0f);
                    break;

                    case 9:
                    newItemTransf.position = new Vector3(9.65f,12f,0f);
                    break;

                    case 10:
                    newItemTransf.position = new Vector3(23f,1f,0f);
                    break;

                    case 11:
                    newItemTransf.position = new Vector3(45f,0f,0f);
                     break;
                }
        		

        		Instantiate(trof, newItemTransf);
        		plyerScrpt.qtdMoedas++;
                if(plyerScrpt.initialHealth-plyerScrpt.playerHealth>100f)
                plyerScrpt.playerHealth+=100f;
        		Debug.Log(plyerScrpt.qtdMoedas);
        	}


 			foreach (Transform child in item_go.transform){
 				if(child.name!="trofeu")
 				Destroy(child.gameObject);
 			}
    }

        void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}



