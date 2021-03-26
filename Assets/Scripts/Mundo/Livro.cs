using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livro : MonoBehaviour
{
    Animator animator;
    public  GameObject         ImagemLivro;
    public  GameObject         iconeLupa;

    private JogadorInteragir   jogador_;
    private bool               colidio;

    void Start()
    {
        jogador_ = FindObjectOfType<JogadorInteragir>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(jogador_.lerLivro && colidio)
        {
            ImagemLivro.SetActive(true);
        } else 
        {
            ImagemLivro.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = true;
            iconeLupa.SetActive(true);
            animator.SetBool("Abrir", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            colidio = false;
            iconeLupa.SetActive(false);
            animator.SetBool("Abrir", false);
        }
    }
}
