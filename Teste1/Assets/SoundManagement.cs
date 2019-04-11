using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
	public static AudioClip plDeathSound;
	public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        plDeathSound = Resources.Load<AudioClip>("plDeath");

        audioSrc=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string c){
    	    }
}
