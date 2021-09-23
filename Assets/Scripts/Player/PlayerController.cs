using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Atributtes Movimentation")]
    [SerializeField]private float SpeedRun;
    [SerializeField]private float StartSpeedRun;
    [SerializeField]public  float ForceJump;
    [SerializeField]public  float MovimentationJump;
    [SerializeField]public  bool  IsRight;
    [SerializeField]private bool  CheckGround;
    [SerializeField]public  bool  Moviment;
    [SerializeField]public  bool  Dialogue;
    [Header("Atributtes Life")]
    [SerializeField]public  float Life;
    [SerializeField]public  float TimeHurt;
    [Header("Atributtes Combat")]
    [SerializeField]public float Damage;
    [SerializeField]public float SpeedAttack;
    [Header("Atributtes Extern")]
    [SerializeField]private float TimeFallHeight;
    [SerializeField]private bool  DamageHeight;
    [Header("Components")]
    [SerializeField]private PlayerControllerInputs PlayerControllerInputs;
    [SerializeField]private Rigidbody2D            Rigidbody2D;
    [SerializeField]private Animator               Animator;
    [SerializeField]private Transform              TransformCheckGround;
    [SerializeField]private AudioSource            SourceEffects;
    [SerializeField]private AudioClip              SwordEffect;

    void Start()
    {
        StartSpeedRun          = SpeedRun;
        Dialogue               = false;
        Moviment               = true;
        IsRight                = false;
        Animator               = GetComponent<Animator>();
        Rigidbody2D            = GetComponent<Rigidbody2D>();
        PlayerControllerInputs = GetComponent<PlayerControllerInputs>();
    }





    void Update()
    {
        Movimentation();
        Combat();
        //CheckDamageHeight();
        CheckDeath();
    }


    void Movimentation()
    {

        
        CheckGround = Physics2D.Linecast(
        transform.position, 
        TransformCheckGround.transform.position, 
        1 << LayerMask.NameToLayer("Ground"));

        if(Moviment && !Dialogue &&!Animator.GetBool("Attack") && !Animator.GetBool("CombatIdle") )
        {Rigidbody2D.velocity = new Vector2(PlayerControllerInputs.AxisHorizontal * SpeedRun, 
        Rigidbody2D.velocity.y);}

        if(!CheckGround){Animator.SetBool("Jump", true);}else{Animator.SetBool("Jump", false);}

        if(PlayerControllerInputs.KeySpace && CheckGround && !Dialogue)
        {
            Rigidbody2D.AddForce(transform.up * ForceJump * Time.fixedDeltaTime, ForceMode2D.Impulse); 
            if(PlayerControllerInputs.AxisHorizontal == 0){SpeedRun = MovimentationJump;}
            else
            {Moviment = false;} 
            Debug.Log(ForceJump * Time.fixedDeltaTime);
            Animator.SetBool("Jump", true);  
        }else if(CheckGround)
        {Animator.SetBool("Jump", false); SpeedRun = StartSpeedRun; Moviment = true;}

        if(PlayerControllerInputs.AxisHorizontal != 0 && !Dialogue)
        {Animator.SetBool("Run", true);}
        else
        {Animator.SetBool("Run", false);}

        if(PlayerControllerInputs.AxisHorizontal > 0 && !IsRight && CheckGround 
        && Moviment && !Dialogue)
        {Flip(); IsRight = true;}
        else 
        if(PlayerControllerInputs.AxisHorizontal < 0 && IsRight && CheckGround)
        {Flip(); IsRight = false;};
    }
    
    void Combat()
    {
        if(PlayerControllerInputs.Mouse1)
        {
            Rigidbody2D.velocity = Vector2.zero;
            Animator.SetBool("CombatIdle", true);
            if(PlayerControllerInputs.Mouse0 && !Animator.GetBool("Attack"))
            {SourceEffects.PlayOneShot(SwordEffect);Animator.SetBool("Attack", true);
            StartCoroutine(DesactiveAnimations(SpeedAttack));}
        }else 
        {Animator.SetBool("CombatIdle", false);
}
    }

    void CheckDeath()
    {
        if(Life <= 0)
        {FunctionDeath();}
    }

    /*void CheckDamageHeight()
    {
        if(!CheckGround)
        {TimeFallHeight += 2 * Time.deltaTime; 
        }else if(CheckGround && !DamageHeight)
        {TimeFallHeight = 0;}

        if(TimeFallHeight >= 3)
        {
            DamageHeight = true;
            if(CheckGround)
            {Hit(TimeFallHeight * 3); TimeFallHeight = 0; DamageHeight = false;}
        }
        
    }*/

    //Functions

    public IEnumerator DesactiveAnimations(float time)
    {
        yield return new WaitForSeconds(time);
        Animator.SetBool("Attack", false);
        StopCoroutine(DesactiveAnimations(time));
    }

    public IEnumerator Hurt()
    {
        do
        {
            Rigidbody2D.velocity = Vector2.zero;
        }while(Animator.GetBool("Hurt"));
        Animator.SetBool("Hurt", true);
        yield return new WaitForSeconds(TimeHurt);
        Animator.SetBool("Hurt", false);
    }

    public void FunctionDeath()
    {
        Animator.SetBool("Death", true);
        Moviment = false;
    }

    public void Hit(float damage)
    {
        Life -= damage;
        StartCoroutine(Hurt());
    }


    
    public void StartDialogue()
    {
        Rigidbody2D.velocity = Vector2.zero;
        Animator.SetBool("Run", false);
        Moviment = false;
        Dialogue = true;
    }




    void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
