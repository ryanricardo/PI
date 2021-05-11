using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour
{
    private EEstadosInimigos EstadoAtual;
    private Vector2          posicaoOriginal;
    private GameObject       gameobjectJogador;
    private int              layer_Jogador;
    private float            distancia;
    private Jogador          jogador;


    private Animator         animator;
    public  Transform        raio;




    void Start()
    {
        animator = GetComponent<Animator>();
        layer_Jogador = LayerMask.GetMask("Player");
        EstadoAtual = EEstadosInimigos.Parado;
        posicaoOriginal = transform.position;
        gameobjectJogador = GameObject.FindGameObjectWithTag("Player");
        jogador = FindObjectOfType<Jogador>();
        
    }

    
    void Update()
    {
        Raio();

        switch(EstadoAtual)
        {
            case EEstadosInimigos.Parado:
                Parado();
                break;

            case EEstadosInimigos.Perseguindo:
                Perseguindo();
                break;
            case EEstadosInimigos.Atacando:
                Invoke("Atacando", 1);
                break;

        }


    }

    void Parado()
    {
        Vector2 voltar = Vector2.MoveTowards(transform.position, posicaoOriginal, 5 * Time.deltaTime);
        transform.position = voltar;
        
        if(transform.position.x == 75.08f)
        {
            animator.SetBool("Correndo", false);
        }
    }

    void Perseguindo()
    {
        Vector2 perseguir = Vector2.MoveTowards(transform.position, gameobjectJogador.transform.position, 5 * Time.deltaTime);
        transform.position = perseguir;
        animator.SetBool("Correndo", true);
    }

    void Atacando()
    {
        jogador.transform.position = new Vector2(-15.53f, -2.11f);
        animator.SetBool("Atacando", false);  
        jogador.vida -= 5; 
    }

    void Raio()
    {
        Ray r = new Ray();
        r.origin = raio.transform.position;
        r.direction = raio.transform.right;
        Debug.DrawLine(r.origin, r.origin + (r.direction * 10), Color.magenta, 1);
        distancia = Vector2.Distance(transform.position, gameobjectJogador.transform.position);

        if(Physics2D.Raycast(r.origin, r.direction, 10, layer_Jogador))
        {
            EstadoAtual = EEstadosInimigos.Perseguindo;

            if(distancia < 2.5)
            {
                animator.SetBool("Correndo", false);
                animator.SetBool("Atacando", true);
                EstadoAtual = EEstadosInimigos.Atacando;

            }

        } else 
        {
            EstadoAtual = EEstadosInimigos.Parado;
            animator.SetBool("Correndo", true);
        }

    }
    

}
