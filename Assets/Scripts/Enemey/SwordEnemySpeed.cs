using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemySpeed : MonoBehaviour
{
    public Animator Animator;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && Animator.GetInteger("Animation") == 4)
        {
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().Hit(0.5f));         
        }
    }
}