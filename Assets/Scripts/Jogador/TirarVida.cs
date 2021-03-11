using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirarVida : MonoBehaviour
{
    public GameObject jogador_;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           jogador_.GetComponent<Jogador>().TomarDano(5);
       }
    }
}