using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    [HideInInspector]public bool           viradoDireita;
    [HideInInspector]public bool           abrigado; 
    [HideInInspector]public bool           correndo;
    [HideInInspector]public bool           caminhando;
    [HideInInspector]public int            sequencia;
    [HideInInspector]public int            numero;
    [HideInInspector]public int            vida               = 100;
    [HideInInspector]public Animator       anim;

    public                  float          velocidade;
    public                  Transform      detectaChao;
    public                  float          forcaX;
    public                  float          forcaY;
    
    private JogadorInteragir  jogador_;
    private Rigidbody2D       rb2; 
    private bool              tocaChao;

    void Start()
    {
        jogador_   = FindObjectOfType<JogadorInteragir>();
        rb2        = GetComponent<Rigidbody2D>();
        anim       = GetComponent<Animator>();
        sequencia  = 0;
        numero     = 0;
        vida       = 100;
        tocaChao   = false;
    }
    void Update()
    {
        Movimentacao();


        tocaChao = Physics2D.Linecast(transform.position, detectaChao.position, 1 << LayerMask.NameToLayer("Chao"));
        Debug.DrawLine(transform.position, detectaChao.position);


    }

    void Movimentacao()
    {
        float translationX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(translationX * velocidade * Time.deltaTime, 0f));

        if(Input.GetButtonDown("Jump") && tocaChao && correndo && numero == 0)
        {
            Debug.Log("pulou");
            rb2.AddForce(new Vector2(0, forcaY), ForceMode2D.Impulse);
            numero += 1;
        } 

        if(Input.GetKeyDown(KeyCode.C) && sequencia == 0)
        {
            sequencia += 1;
            anim.SetBool("agachando", true);
        } else if(Input.GetKeyDown(KeyCode.C) && sequencia == 1 || caminhando)
        {
            anim.SetBool("agachando", false);
            sequencia = 0;
        }

        if (Input.GetKey("left shift") && caminhando)
        {
            correndo = true;
            anim.SetBool("correndo", true);
            velocidade = 8;
        } else 
        {
            correndo = false;
            velocidade = 4f;
            anim.SetBool("correndo", false);
        }


        if(translationX != 0)
        {
            caminhando = true;
            anim.SetBool("caminhando", true);
        } else
        {
            caminhando = false;
            anim.SetBool("caminhando", false);
        }

        if(translationX > 0 && viradoDireita)
        {
            Flip();
        } 
        if(translationX < 0 && !viradoDireita)
        {
            Flip();
        }


        if(!tocaChao)
        {
            anim.SetBool("pulando", true);
        } else if(numero == 1)
        {
            anim.SetBool("pulando", false);
            rb2.velocity = Vector2.zero;
            numero = 0;
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
