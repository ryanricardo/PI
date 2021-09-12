using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoots : MonoBehaviour
{
    public int countFoot;

    private PlayerController PlayerController;

    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground") && PlayerController.Animator.GetBool("Run"))
        {
            PlayerController.AudioSource.PlayOneShot(PlayerController.Clips[countFoot]);
        }
    }
}

