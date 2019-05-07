using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
	public static AudioClip plDeathSound, plHitSound,plJumpSound;
	public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {   
        plDeathSound = Resources.Load<AudioClip>("plDeath");
        plHitSound = Resources.Load<AudioClip>("plHit");
        plJumpSound = Resources.Load<AudioClip>("plJump");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void PlaySound(string c){
        switch(c){
            case "death":
                audioSrc.PlayOneShot(plDeathSound);
            break;
            case "hit":
                audioSrc.PlayOneShot(plHitSound);
            break;
            case "jump":
                //audioSrc.PlayOneShot(plJumpSound);
            break;
            default:
            break;
        }
    }
}
