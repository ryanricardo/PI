using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faca : MonoBehaviour
{

    private Lobo lobo;
    private JogadorInteragir jogadorInteragir;
    
    void Start()
    {

    }

    
    void Update()
    {
        jogadorInteragir = FindObjectOfType<JogadorInteragir>();
        lobo = FindObjectOfType<Lobo>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Inimigo"))
        {
            Debug.Log("Acertou");
            lobo.TomarDano();
        }
    }
}
