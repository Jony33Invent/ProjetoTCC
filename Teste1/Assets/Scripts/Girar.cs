using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girar : MonoBehaviour
{
	private float x;
    public float speedGiro = 1f;
    public float sentidoGiro = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Gira o objeto
		transform.rotation = Quaternion.AngleAxis(x*sentidoGiro, Vector3.back);
		x+=speedGiro;
    }
}
