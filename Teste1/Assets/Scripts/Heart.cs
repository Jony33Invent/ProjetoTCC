using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public float Health;
    public int numberOfHeart;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public PlayerController player;

    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Health = player.playerHealth/100f;
        

        if (Health > numberOfHeart)
        {
            Health = numberOfHeart;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if( i < Health)
            {
                hearts[i].sprite = FullHeart;

            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }

            if(i < numberOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
