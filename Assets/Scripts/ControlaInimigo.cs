using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {
    public float velocidade =5;
    public GameObject jogador;

    // Use this for initialization
    void Start () {
     //  distanciaCompensar = transform.position - jogador.transform.position;



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 direcao = jogador.transform.position - transform.position;
      


        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);
    }
}
