using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerController PlayerController;
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerController.CheckGround)
        {
            PlayerController.rb2.AddForce(PlayerController.transform.up * 5, ForceMode2D.Impulse);
        }
    }
}
