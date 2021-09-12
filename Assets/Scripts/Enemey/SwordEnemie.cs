using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemie : MonoBehaviour
{
    
    public Animator Animator;
    private Enemie enemie;

    void Start()
    {
        enemie = FindObjectOfType<Enemie>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && Animator.GetInteger("Animation") == 4)
        {
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().Hit(enemie.Damage));         
        }
    }
}
