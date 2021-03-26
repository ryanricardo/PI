using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Porta : MonoBehaviour
{
    private JogadorInteragir     jogador_;
    private AudioSource          audioSource;
    private Animator             anim;
    public  GameObject           Colisor;

    [HideInInspector] public  bool colidio;

    void Start()
    {
        jogador_        = FindObjectOfType<JogadorInteragir>();
        audioSource     = GetComponent<AudioSource>();
        anim            = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(colidio && jogador_.abrirPorta)
        { 
            audioSource.Play();
            Colisor.GetComponent<Collider2D>().isTrigger = true;
            anim.SetBool("AbrirPorta", true);
        } else if(colidio == false)
        {
            Colisor.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
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
