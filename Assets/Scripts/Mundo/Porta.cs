using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject Jogador;
    private Animator anim;
    [HideInInspector] public  bool colidio;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(colidio && Jogador.GetComponent<JogadorInteragir>().abrirPorta)
        {
            anim.SetBool("AbrirPorta", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = false;
            anim.SetBool("AbrirPorta", false);
        }
    }
    
}
