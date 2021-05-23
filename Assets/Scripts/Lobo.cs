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
    private float            chronometer; 
    private Jogador          jogador;


    private Animator         animator;
    private Rigidbody2D      rb2;
    [HideInInspector] public bool corra;
    public  float            vida;
    public  Transform        raio;




    void Start()
    {
        vida = 100;
        chronometer = 0;
        animator = GetComponent<Animator>();
        layer_Jogador = LayerMask.GetMask("Player");
        EstadoAtual = EEstadosInimigos.Parado;
        posicaoOriginal = transform.position;
        gameobjectJogador = GameObject.FindGameObjectWithTag("Player");
        jogador = FindObjectOfType<Jogador>();
        rb2 = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        Raio();

        if(vida <= 0)
        {
            Destroy(gameObject);
        }
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
        
        if(rb2.velocity.x == 0f)
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
        chronometer += Time.deltaTime;
        if(chronometer > 1 && distancia < 2.5)
        {
            jogador.tomarDano = true;
            jogador.TomarDano(20);
            animator.SetBool("Atacando", false);
            chronometer = 0;   
        }

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

    public void TomarDano()
    {
        Debug.Log(vida);
        vida -= 50;
        
    }
    

}
