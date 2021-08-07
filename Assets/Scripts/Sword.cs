using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    
    public  Animator Animator;
    

    void Start()
    {
    }

    
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemie") && Animator.GetBool("Attack") == true)
        {
            other.gameObject.GetComponent<Enemie>().CurrentStates = "Hurt";
        }
    }
}
