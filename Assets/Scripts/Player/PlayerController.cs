using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    public                      Animator        Animator;
    public                      Transform       TransformCheckGround;
    public                      AudioSource     AudioSource;
    public                      AudioClip[]     Clips;
    [HideInInspector]public     Rigidbody2D     rb2;
    
    [Header("Inputs")]
    [HideInInspector]public     bool            MouseButtonFire0;
    [HideInInspector]public     bool            MouseButtonFire1;
    [HideInInspector]public     bool            KeyCodeEDown;
    [HideInInspector]public     bool            KeyCodeSpaceDown;
    
    [Header("Variables")]
    private                     bool            Right;
    private                     float           AxisHorizontal;
    public                      float           Speed;
    public                      float           Life;
    [HideInInspector]public     bool            Hurt;
    [HideInInspector]public     RaycastHit2D    CheckGround;
    [HideInInspector]public     bool            Moviment;
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
        
        if(KeyCodeSpaceDown && CheckGround && !Hurt && 
        !Animator.GetBool("Attack") && !Animator.GetBool("CombatIdle"))
        {
            rb2.AddForce(transform.up * 7, ForceMode2D.Impulse);
        }

        if(AxisHorizontal > 0 && !Right && Moviment)
        {
            Flip();
            Right = true;
        }else if(AxisHorizontal < 0 && Right && Moviment) 
        {
            Flip();
            Right = false;
        }
        
    }

    void Animations()
    {
        if(MouseButtonFire1)
        {
            Moviment = false;
            Animator.SetBool("CombatIdle", true);
            if(MouseButtonFire0)
            {
                Moviment = false;
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
            Moviment = false;
        }else if(!Animator.GetBool("CombatIdle") && !Animator.GetBool("Attack") 
        && !Animator.GetBool("Death"))
        {
            Animator.SetBool("Jump", false);
            Moviment = true;
        }

        if(AxisHorizontal != 0 && Moviment)
        {
            Animator.SetBool("Run", true);
        }else if(AxisHorizontal == 0)
        {
            Animator.SetBool("Run", false);
        }

        if(Hurt)
        {
            Moviment = false;
            Animator.SetBool("Hurt", true);
        }else if(!Animator.GetBool("CombatIdle") && !Animator.GetBool("Attack")
        && !Animator.GetBool("Death") && CheckGround)
        {
            Moviment = true;
            Animator.SetBool("Hurt", false);
        }

        if(Death)
        {
            Animator.SetBool("Death", true);
        }

        
    }

    void Inputs()
    {
        if(Input.GetMouseButton(1))
        {
            MouseButtonFire1 = true;
        }else 
        {
            MouseButtonFire1 = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            KeyCodeSpaceDown = true;
        }else 
        {
            KeyCodeSpaceDown = false;
        }

        if(Input.GetMouseButton(0))
        {
            MouseButtonFire0 = true;
        }else 
        {
            MouseButtonFire0 = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            KeyCodeEDown = true;
        }else 
        {
            KeyCodeEDown = false;
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
