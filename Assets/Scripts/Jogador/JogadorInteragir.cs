using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorInteragir : MonoBehaviour
{   

    [HideInInspector]public bool           abrirPorta;
    [HideInInspector]public bool           lerLivro; 
    [HideInInspector]public bool           posicaoAtaque;
    
    public  GameObject Jogador;
    public  GameObject Inimigo;
    public  GameObject Faca;

    private bool     atacando;
    private bool     facaAtingiu;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            abrirPorta = true;
            lerLivro   = true;
        } else 
        {
            lerLivro   = false;
            abrirPorta = false;
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            posicaoAtaque = true;
            if(Jogador.GetComponent<Jogador>().correndo && posicaoAtaque)
            {
                anim.SetBool("atacando", false);
                anim.SetBool("andando ataque01", true);
            } else 
            {
                anim.SetBool("andando ataque01", false);
            }
            anim.SetBool("atacando", true);

        } else 
        {
            posicaoAtaque = false;
            anim.SetBool("atacando", false);
            anim.SetBool("andando ataque01", false);
        }

        if(posicaoAtaque && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Atacou");
            atacando = true;
            anim.SetBool("ataque01", true);
        } else 
        {
            atacando = false;
            anim.SetBool("ataque01", false);
        }

        DanoFaca();
        
    }

    private void DanoFaca()
    {
        if(facaAtingiu && atacando)
        {
            Inimigo.GetComponent<OutroInimigo>().TomarDano(10);
        }
    }

    private void DanoArmaLeve(int dan)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Encostou no Inimigo");
            facaAtingiu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Saiu do Inimigo");
            facaAtingiu = false;
        }
    }

    

}
