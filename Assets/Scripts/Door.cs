using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator Animator;
    private PlayerInputs PlayerInputs;
    private PlayerController PlayerController;
    private bool Open;
    void Start()
    {
        Open = false;
        Animator = GetComponent<Animator>();
        PlayerController = FindObjectOfType<PlayerController>();
        PlayerInputs = FindObjectOfType<PlayerInputs>();
    }

    
    void Update()
    {
        OpenAndClose();
    }

    void OpenAndClose()
    {

        float DistancePlayer = Vector2.Distance(transform.position, PlayerController.transform.position);

        if(DistancePlayer <= 2 && PlayerInputs.pressE)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Animation("Open", true);
        }else if(DistancePlayer > 2)
        {
            Animation("Open", false);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void Animation(string name, bool situation)
    {
        Animator.SetBool(name, situation);
    }

}
