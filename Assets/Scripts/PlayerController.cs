﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    private                     Rigidbody2D     rb2;
    private                     Animator        Animator;
    public                      Transform       TransformCheckGround;
    [Header("Variables")]
    private                     bool            Right;
    private                     bool            KeyCodeLControl;
    private                     bool            KeyCodeSpaceDown;
    private                     float           AxisHorizontal;
    private                     RaycastHit2D    CheckGround;
    public                      float           Speed;
    public                      float           Life;
    public                      bool            Hurt;
    [HideInInspector]           bool            Moviment;
    [HideInInspector]public     bool            Death;

    void Start()
    {
        Moviment            = true;
        Hurt                = false;
        Death               = false;
        Right               = false;
        Life                = 2;
        rb2                 = GetComponent<Rigidbody2D>();
        Animator            = GetComponent<Animator>();
    }

    void Update()
    {
        Actions();
        Animations();
        Inputs();
        Variables();
    }

    void Actions()
    {
        if(Moviment)
        {
            rb2.velocity = new Vector2(AxisHorizontal * Speed, rb2.velocity.y);
        }

        if(Life <= 0)
        {
            Death = true;
            Moviment = false;
        }
        
        
        if(KeyCodeSpaceDown && CheckGround && 
        !Animator.GetBool("Attack") && !Animator.GetBool("CombatIdle"))
        {
            rb2.AddForce(transform.up * 7, ForceMode2D.Impulse);
        }

        if(AxisHorizontal > 0 && !Right)
        {
            Flip();
            Right = true;
        }else if(AxisHorizontal < 0 && Right) 
        {
            Flip();
            Right = false;
        }
        
    }

    void Animations()
    {
        if(KeyCodeLControl)
        {
            Animator.SetBool("CombatIdle", true);
            if(KeyCodeSpaceDown)
            {
                Animator.SetBool("Attack", true);
                StartCoroutine(DesactiveAnimations(0.5f));
            }
        }else 
        {
            Animator.SetBool("CombatIdle", false);
        }

        if(!CheckGround)
        {
            Animator.SetBool("Jump", true);
        }else 
        {
            Animator.SetBool("Jump", false);
        }

        if(AxisHorizontal != 0)
        {
            Animator.SetBool("Run", true);
        }else if(AxisHorizontal == 0)
        {
            Animator.SetBool("Run", false);
        }

        if(Hurt)
        {
            Animator.SetBool("Hurt", true);
        }else 
        {
            Animator.SetBool("Hurt", false);
        }

        if(Death)
        {
            Animator.SetBool("Death", true);
        }
    }

    void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            KeyCodeSpaceDown = true;
        }else 
        {
            KeyCodeSpaceDown = false;
        }

        if(Input.GetKey(KeyCode.LeftControl))
        {
            KeyCodeLControl = true;
        }else 
        {
            KeyCodeLControl = false;
        }

    }

    void Variables()
    {
        AxisHorizontal = Input.GetAxis("Horizontal");
        
        CheckGround = Physics2D.Linecast(transform.position, 
        TransformCheckGround.transform.position, 1 << LayerMask.NameToLayer("Ground"));

    }


    // Functions

    public IEnumerator DesactiveAnimations(float time)
    {
        yield return new WaitForSeconds(time);
        Animator.SetBool("Attack", false);
        StopCoroutine(DesactiveAnimations(0));
    }

    public IEnumerator Hit(float Damage)
    {
        Moviment = false;
        Life -= Damage;
        Hurt = true;
        yield return new WaitForSeconds(1);
        Hurt = false;
        Moviment = true;
    }
    

    void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
