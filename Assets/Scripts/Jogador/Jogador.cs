using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogador : ReferenciasJogador
{
    void Start()
    {
        anim = GetComponent<Animator>();
        sequencia  = 0;
        velocidade = 5; 
        vida       = 100;
    }

    
    void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        float translationX = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(translationX * velocidade * Time.deltaTime, 0f));


        if (Input.GetKey("left shift") )
        {
            anim.SetBool("correndo", true);
            velocidade = 12;
        } else 
        {
            velocidade = 5;
            anim.SetBool("correndo", false);
        }

        if(translationX != 0)
        {
            anim.SetBool("caminhando", true);
        } else
        {
            anim.SetBool("caminhando", false);
        }

        if(translationX > 0 && viradoDireita)
        {
            Flip();
        } else if (translationX < 0 && !viradoDireita)
        {
            Flip();
        }
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }


    public void TomarDano(int dano)
    {
        vida -= dano;
        sequencia++;
        Debug.Log("sua vida esta em " + vida);
        vidaUI.sprite = vidasSprite[sequencia];
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Abrigado"))
        {
            abrigado = true;
        } 
    }

    public void OnTriggerExit2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Abrigado"))
        {
            abrigado = false;
        }
    }
}
