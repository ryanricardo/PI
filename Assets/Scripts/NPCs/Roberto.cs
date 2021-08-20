using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roberto : FunctionsNPCs
{
    
    void Start()
    {
        PlayerController    = FindObjectOfType<PlayerController>();    
        CountDialogue       = -1;
    }

    
    void Update()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        float DistancePlayer = Vector2.Distance(transform.position, PlayerController.transform.position);

        if(DistancePlayer <= 2 && PlayerController.KeyCodeEDown)
        {
            TextDialogue.gameObject.SetActive(true);
            PlayerController.Moviment = false;
            CountDialogue += 1;
            Dialogue();
        }
        
        if(CountDialogue == LimitCountDialogue)
        {
            TextDialogue.gameObject.SetActive(false);
            PlayerController.Moviment = true;
            CountDialogue = -1;
        }
    }

    public void Dialogue()
    {
        TextDialogue.text = TypesDialogues[CountDialogue];
    }

}
