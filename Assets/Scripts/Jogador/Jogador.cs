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
    [HideInInspector]public int            sequencia;
    [HideInInspector]public int            contagem;
    [HideInInspector]public int            vida               = 100;
    [HideInInspector]public float          velocidade;
    [HideInInspector]public Animator       anim;

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
        contagem   = 0;
        vida       = 100;
        tocaChao   = false;
    }
    void Update()
    {
        Movimentacao();
        Pular();

        tocaChao = Physics2D.Linecast(transform.position, detectaChao.position, 1 << LayerMask.NameToLayer("Chao"));
        Debug.DrawLine(transform.position, detectaChao.position);


    }

    void Movimentacao()
    {
        float translationX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(translationX * velocidade * Time.deltaTime, 0f));

        if(Input.GetKeyDown(KeyCode.C) && !correndo && sequencia == 0)
        {
            sequencia += 1;
            anim.SetBool("agachando", true);
        } else if(Input.GetKeyDown(KeyCode.C) && sequencia == 1)
        {
            anim.SetBool("agachando", false);
            sequencia = 0;
        }

        if (Input.GetKey("left shift") )
        {
            anim.SetBool("correndo", true);
            velocidade = 8;
        } else 
        {
            velocidade = 5.5f;
            anim.SetBool("correndo", false);
        }


        if(translationX != 0)
        {
            correndo = true;
            anim.SetBool("caminhando", true);
        } else
        {
            correndo = false;
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

    void Pular()
    {
        if(Input.GetButtonDown("Jump") && tocaChao)
        {
            Debug.Log("Pulou");
            rb2.AddForce(new Vector2(0, forcaY), ForceMode2D.Impulse);
            contagem += 1;
        } 

        if(!tocaChao)
        {
            anim.SetBool("pulando", true);
        } else 
        {
            anim.SetBool("pulando", false);
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
