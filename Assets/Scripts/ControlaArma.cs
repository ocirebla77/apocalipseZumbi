using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {
    public GameObject bala;
    public GameObject canoDaArma;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bala, canoDaArma.transform.position, canoDaArma.transform.rotation);

        }
		
	}
}
