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
    
    public  Image      Armas;
    public  Sprite[]   spriteArmas;


    private Lobo lobo;
    private Animator anim;
    public  bool     atacando;
    private bool     ataque;
    private bool     facaAtingiu;
    private GameObject inimigo;


    private void Awake() 
    {
        Armas.sprite = spriteArmas[0];
    }

    void Start()
    {
        lobo       = FindObjectOfType<Lobo>();
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


    }




    
}


