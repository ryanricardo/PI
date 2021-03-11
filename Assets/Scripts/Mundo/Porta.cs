using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject Jogador;
    private Animator anim;
    private bool colidio;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = false;
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(colidio && Jogador.GetComponent<JogadorInteragir>().abrirPorta)
        {
            GetComponent<Collider2D>().isTrigger = true;
            anim.SetBool("AbrirPorta", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = false;
            GetComponent<Collider2D>().isTrigger = false;
            anim.SetBool("AbrirPorta", false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = true;
        }
    }

}
