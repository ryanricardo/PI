using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFall : MonoBehaviour
{
    [Header("Atributtes WoodFall")]
    [SerializeField]private bool Collision;
    [SerializeField]private bool ActiveOneTime;
    [Header("Components")]
    private Animator Animator;




    void Start()
    {
        Collision     = false;
        ActiveOneTime = true;
        Animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Collision)
        {
            if(ActiveOneTime){Animator.SetBool("Shack", true); StartCoroutine(StartFall(3)); ActiveOneTime = false;}
        }else 
        {
            StopCoroutine(StartFall(3));
            Animator.SetBool("Shack", false); 
            Animator.SetBool("Falling", false); 
        }
        
    }

    IEnumerator StartFall(float time)
    {
        yield return new WaitForSeconds(time);
        Animator.SetBool("Shack", false); 
        Animator.SetBool("Falling", true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Collision = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ActiveOneTime = true;
            Collision = false;
        }
    }
}
