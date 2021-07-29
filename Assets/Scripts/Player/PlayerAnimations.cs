using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
   
    private PlayerController PlayerController;
    private Animator         Animator;
  
    void Start()
    {

        PlayerController = FindObjectOfType<PlayerController>();
        Animator         = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(PlayerController.AxisHorizontal != 0)
        {
            ActiveAnimation("Run", true);
        } else 
        {
            ActiveAnimation("Run", false);
        }
    }

    void ActiveAnimation(string name, bool situation)
    {
        Animator.SetBool(name, situation);
    }


}
