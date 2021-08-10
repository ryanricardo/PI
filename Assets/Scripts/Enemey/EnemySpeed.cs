using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeed : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D         rb2;
    private Animator            Animator;
    private PlayerController    PlayerController;
    private Transform           TransformPlayerController;

    [Header("Variables")]
    private Vector2             FollowPlayerController;
    private bool                Right;
    private bool                Attacking;
    private float               distancePlayer;

    public  int                 Life;
    public  float               Speed;
    [HideInInspector]public bool                 Hurt;
    [HideInInspector]public string               CurrentStates;
    [HideInInspector]public bool                 Death;


    void Start()
    {
        Attacking                   = false;
        Death                       = false;
        Right                       = true;
        Hurt                        = true;
        PlayerController            = FindObjectOfType<PlayerController>();
        TransformPlayerController   = FindObjectOfType<PlayerController>().transform;
        Animator                    = GetComponent<Animator>();
        rb2                         = GetComponent<Rigidbody2D>();

        CurrentStates               = "Idle";
    }

    
    void Update()
    {
        distancePlayer              = Vector2.Distance(transform.position, TransformPlayerController.transform.position);
        FollowPlayerController      = Vector2.MoveTowards(transform.position, TransformPlayerController.transform.position, Speed * Time.deltaTime);
        
        if(PlayerController.Death){CurrentStates = "Empty";}

        if((transform.position.x - TransformPlayerController.transform.position.x) < 0 && !Right)
        {
            Flip();
            Right = true;
        }else if((transform.position.x - TransformPlayerController.transform.position.x) > 0 && Right)
        {
            Flip();
            Right = false;
        }

        if(Life <= 0){CurrentStates = "Death";}




        switch(CurrentStates)
        {
            case "Empty":
            Animator.SetInteger("Animation", 0);
            break;

            case "Idle":
            UpdateIdle();
            break;

            case "Stalking":
            UpdateStalking();
            break;

            case "Attacking":
            Hurt = true;
            UpdateAttacking();
            break;

            case "Hurt":
            if(Hurt){StartCoroutine(HurtLoop()); Hurt = false;}
            break;

            case "Death":
            if(!Death){Animator.SetInteger("Animation", 6); Destroy(gameObject, 3); Death = true;}
            break;
        }


    }

    void UpdateIdle()
    {
        
        Animator.SetInteger("Animation", 0);

        if(distancePlayer <= 5){CurrentStates = "Stalking";}
    }

    void UpdateStalking()
    {
        if(distancePlayer <= 1 && !PlayerController.Death)
        {
            CurrentStates = "Attacking";
        }else 
        {
            if(distancePlayer <= 5)
            {
                transform.position = FollowPlayerController; 
                Animator.SetInteger("Animation", 1);
            }else
            {
                CurrentStates = "Idle";
            }
        }
    }

    void UpdateAttacking()
    {
        if(distancePlayer <= 1 && !Attacking)
        {
            StartCoroutine(AttackingLoop());
            Attacking = true;
        }else 
        {
            StopCoroutine(AttackingLoop());
            if(distancePlayer <= 5 && !Attacking)
            {
               CurrentStates = "Stalking";
            }else if(!Attacking)
            {
                CurrentStates = "Idle";
            }
        }
    }

    


    IEnumerator HurtLoop()
    {
        Animator.SetInteger("Animation", 5);
        Life -= 1;
        yield return new WaitForSeconds(0.5f);
        CurrentStates = "Attacking";
    }
    IEnumerator AttackingLoop()
    {
        Animator.SetInteger("Animation", 3);
        yield return new WaitForSeconds(0.5f);
        Animator.SetInteger("Animation", 4);
        yield return new WaitForSeconds(0.5f);
        Attacking = false;
    }


    void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }


    

}