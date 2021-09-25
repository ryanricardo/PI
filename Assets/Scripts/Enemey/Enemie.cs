using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemie : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private Rigidbody2D         rb2;
    [SerializeField]private Animator            Animator;
    [SerializeField]private PlayerController    PlayerController;
    [SerializeField]private Transform           TransformPlayerController;
    [SerializeField]private TextMeshProUGUI     TextLife;
    [SerializeField]private Vector2             FollowPlayerController;
    

    [Header("Atributtes Enemie")]
    [SerializeField]public                      float               Damage;
    [SerializeField]public                      float               SpeedRun;
    [SerializeField]private                     float               SpeedAttack;
    [SerializeField]private                     float               distancePlayer;
    [SerializeField]private                     float               MinimalDistancePlayer;
    [SerializeField]public                      float               Life;
    [SerializeField]public                      float               TimeHurt;
    [SerializeField]public                      string              CurrentStates;
    [SerializeField]public                      bool                HitOneTime;
    [SerializeField]private                     bool                Right;
    [SerializeField]private                     bool                Attacking;
    [SerializeField]public                      bool                Death;
    [SerializeField]public                      bool                Hurt;
    [SerializeField]public                      bool                BossDeath;



    void Start()
    {
        HitOneTime                  = true;
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
        BossDeath                   = Life <= 0 ? true : false;
        distancePlayer              = Vector2.Distance(transform.position, TransformPlayerController.transform.position);
        FollowPlayerController      = Vector2.MoveTowards(transform.position, TransformPlayerController.transform.position, SpeedRun * Time.deltaTime);
        TextLife.text               = Life.ToString();
        if(Life <= 0){Life = 0;}

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
        if(PlayerController.Life <= 0 ){CurrentStates = "Empty";}



        switch(CurrentStates)
        {
            case "Empty":
            Animator.SetInteger("Animation", 0);
            break;

            case "Idle":
            Hurt = true;
            UpdateIdle();
            break;

            case "Stalking":
            Hurt = true;
            UpdateStalking();
            break;

            case "Attacking":
            Hurt = true;
            UpdateAttacking();
            break;

            case "Hurt":
            if(Hurt){StartCoroutine(HurtLoop()); Hurt = false; }
            break;

            case "Death":
            if(!Death)
            {Animator.SetInteger("Animation", 6); Destroy(gameObject, 3); Death = true;
            TextLife.gameObject.SetActive(false);}
            break;
        }


    }

    void UpdateIdle()
    {
        
        Animator.SetInteger("Animation", 0);

        if(distancePlayer <= MinimalDistancePlayer){CurrentStates = "Stalking";}
    }

    void UpdateStalking()
    {
        if(distancePlayer <= 1)
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
            if(distancePlayer <= MinimalDistancePlayer && !Attacking)
            {
               CurrentStates = "Stalking";
            }else if(!Attacking)
            {
                CurrentStates = "Idle";
            }
        }
    }

    
    public void Hit(float damage)
    {
        if(HitOneTime)
        {
            Life -= damage;
            CurrentStates = "Hurt";
            HitOneTime = false;
        }
    }

    IEnumerator HurtLoop()
    {
        Animator.SetInteger("Animation", 5);
        yield return new WaitForSeconds(TimeHurt);
        HitOneTime = true;
        if(distancePlayer <= MinimalDistancePlayer)
        {
            CurrentStates = "Stalking";
        }
        else
        {
            if(distancePlayer <= 1)
            {
                CurrentStates = "Attack";
            }else 
            {
                CurrentStates = "Idle";
            }
        }
    }
    IEnumerator AttackingLoop()
    {
        Animator.SetInteger("Animation", 3);
        yield return new WaitForSeconds(SpeedAttack);
        Animator.SetInteger("Animation", 4);
        yield return new WaitForSeconds(SpeedAttack);
        Attacking = false;
    }


    void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }


    

}
