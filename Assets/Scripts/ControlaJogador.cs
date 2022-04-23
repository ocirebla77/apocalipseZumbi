﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {
    public float Velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;

     void Start()
    {
        Time.timeScale = 1;
    }


    // Update is called once per frame
    void Update () {

      float eixoX = Input.GetAxis("Horizontal");
      float eixoZ = Input.GetAxis("Vertical");
      direcao = new Vector3(eixoX, 0, eixoZ);

        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + 
            (direcao * Velocidade * Time.deltaTime));

    //    transform.Translate(direcao * Velocidade * Time.deltaTime);

        if (direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if(Vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("apocalipse-zumbi");

            }
        }
		
	}

    void FixedUpdate()
    {
        RaycastHit impacto;
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction*100, Color.red);


        GetComponent<Rigidbody>().MovePosition
        (GetComponent<Rigidbody>().position +
        (direcao * Velocidade * Time.deltaTime));

        if (Physics.Raycast(raio, out impacto, 100,MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
 
        }


    }
}
