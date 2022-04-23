using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {
    public float velocidade =5;
    public GameObject jogador;

    // Use this for initialization
    void Start () {
        //  distanciaCompensar = transform.position - jogador.transform.position;

        jogador = GameObject.FindWithTag("jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 direcao = jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

        GetComponent<Rigidbody>().MoveRotation(novaRotacao);




        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        if (distancia>2.5)
        {

            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
                direcao.normalized * velocidade * Time.deltaTime);

            GetComponent<Animator>().SetBool("atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("atacando", true);

        }

       
    }

    void AtacaJogador()
    {
        Time.timeScale = 0;
        jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        jogador.GetComponent<ControlaJogador>().Vivo = false;


    }
}
