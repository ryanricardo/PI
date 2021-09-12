using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public enum States
    {
        NoTalking,
        Talking,
    };

    [Header("Atributtes Dialogue")]
    public                  string[]            TypesDialogues;
    public                  TextMeshProUGUI     TextDialogue;
    public                  bool                PlayDialogue;
    public                  bool                SkippedStartDialogue;
    private                 int                 CountDialogue; 
    private                 int                 LimitCountDialogue;
    [Header("Atributtes Distance")]
    public                  float               distanceInteract;
    private                 float               DistancePlayer;

    public                  States              StatesCurrent;
    public                  bool                OneTime;
    

    [HideInInspector]public PlayerController    PlayerController;


    

    

    

    void Start()
    {
        StatesCurrent       = States.NoTalking;
        PlayerController    = FindObjectOfType<PlayerController>();    
        CountDialogue       = -1;
        LimitCountDialogue  = TypesDialogues.Length;
    }

    
    void Update()
    {
        switch(StatesCurrent)
        {
            case States.NoTalking:
            Observer();
            UpdateNoTalking();
            break;
            case States.Talking:
            Observer();
            UpdateTalking();
            break;
        }
    }

    void Observer()
    {
        DistancePlayer = Vector2.Distance(transform.position, PlayerController.transform.position);
    }

    void UpdateNoTalking()
    {
        PlayerController.Moviment = true;
        TextDialogue.gameObject.SetActive(false);
        if(DistancePlayer <= distanceInteract & PlayerController.KeyCodeEDown 
        || SkippedStartDialogue && DistancePlayer <= distanceInteract)
        {
            StatesCurrent = States.Talking;
        }
    }

    void UpdateTalking()
    {
        
        if(PlayDialogue)
        {
            PlayerController.Moviment = false;
            TextDialogue.gameObject.SetActive(true);
            StartCoroutine(Talking());
            PlayDialogue = false;
        }
        if(OneTime)
        {
            FindObjectOfType<AudioController>().PlayMusic(0);
            OneTime = false;
        }else if(CountDialogue == LimitCountDialogue)
        {
            StatesCurrent = States.NoTalking;
        }
        
        
    }

    IEnumerator Talking()
    {
        
        while(CountDialogue < LimitCountDialogue)
        {
            yield return new WaitForSeconds(3);
            CountDialogue += 1;
            TextDialogue.text = TypesDialogues[CountDialogue];
        }

    }







    



}
