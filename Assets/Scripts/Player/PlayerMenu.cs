using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField]private Animator Animator;
    [SerializeField]public  Vector3  NewPosition;
    [SerializeField]public  Vector3  StartPosition;
    [SerializeField]private bool     MoveNow;

    void Start()
    {
        MoveNow  = false;
        Animator = GetComponent<Animator>();
        StartPosition = transform.position;
        transform.position = StartPosition;
    }

    
    void Update()
    {
        if(MoveNow)
        {   
            NewPosition = new Vector2(20, -3);
            transform.position = Vector2.MoveTowards(transform.position, NewPosition, 5 * Time.deltaTime);
        }

    }

    public void Move()
    {
        Animator.SetBool("Run", true);
        MoveNow     = true;
    }
}
