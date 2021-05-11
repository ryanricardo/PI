using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogadorInteragir : MonoBehaviour
{   

    [HideInInspector]public bool           abrirPorta;
    [HideInInspector]public bool           lerLivro; 
    [HideInInspector]public bool           posicaoAtaque;
    [HideInInspector]public int            armas;
    
    public  GameObject Faca;
    public  Image      Armas;
    public  Sprite[]   spriteArmas;

    private OutroInimigo  inimigo_;
    private Animator anim;
    private bool     atacando;
    private bool     ataque;
    private bool     facaAtingiu;


    private void Awake() 
    {
        Armas.sprite = spriteArmas[0];
    }

    void Start()
    {
        inimigo_   = FindObjectOfType<OutroInimigo>();
        anim       = GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            armas = 0;
            anim.SetInteger("armas", 0);
            Armas.sprite = spriteArmas[0];
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            armas = 1;
            anim.SetInteger("armas", 1);
            Armas.sprite = spriteArmas[1];
        }

        if(Input.GetMouseButton(1))
        {
            ataque = true;
            anim.SetBool("ataque", true);
        } else 
        {
            anim.SetBool("ataque", false);
        }

        if(Input.GetMouseButtonDown(0) && ataque)
        {
            anim.SetBool("ataque", false);
            anim.SetBool("atacando", true);
            atacando = true;
        } else 
        {
            anim.SetBool("atacando", false);
        }
        
        DanoFaca();
        
    }

    private void DanoFaca()
    {
        if(facaAtingiu && atacando)
        {
            inimigo_.TomarDano(10);
    }


    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Encostou no Inimigo");
            facaAtingiu = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Saiu do Inimigo");
            facaAtingiu = false;
        }
    }

    

}
}
