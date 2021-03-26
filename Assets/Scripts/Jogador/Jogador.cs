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
    [HideInInspector]public int            vida               = 100;
    [HideInInspector]public float          velocidade;
    [HideInInspector]public Animator       anim;

    public                  float          forcaX;
    public                  float          forcaY;

    private JogadorInteragir  jogador_;
    private Rigidbody2D rb2; 
    private bool        chao;   

    void Start()
    {
        jogador_   = FindObjectOfType<JogadorInteragir>();
        rb2        = GetComponent<Rigidbody2D>();
        anim       = GetComponent<Animator>();
        sequencia  = 0;
        vida       = 100;
    }
    void Update()
    {
        Movimentacao();
        Pular();
    }

    void Movimentacao()
    {
        float translationX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(translationX * velocidade * Time.deltaTime, 0f));

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
        if(Input.GetButtonDown("Jump"))
        {
            rb2.AddForce(new Vector2(forcaX, forcaY), ForceMode2D.Impulse);
            anim.SetBool("pulando", true);
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

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Chão"))
        {
            Debug.Log("saiu do chão");
            chao = true;
            anim.SetBool("pulando", true);
            anim.SetBool("caindo", true);
        } 
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Chão"))
        {
            if(chao)
            {
                anim.SetBool("caindo", false);
                anim.SetBool("encostando", true);
                Debug.Log("entrou do chão");
            }
        } 
    }
}
