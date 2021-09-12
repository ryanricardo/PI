using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public enum EStates
    {
        Talking,
        NoTalking,
    }

    public enum ETypeBots
    {
        NPCs,
        Enemies,
    }
    


    [Header("States")]
    public  EStates             StatesCurrent;
    public  ETypeBots           TypeBots;
    [Header("Components")]
    public  PlayerController    PlayerController;
    public  TextMeshProUGUI     TextDialogue;
    [Header("Atributtes Distance")]
    public  float               DistancePlayer;
    public  float               MinimiumDistance;
    [Header("Atributtes Dialogues")]
    public  string[]            TypesDialogues;
    public  int                 CountDialogue;
    public  int                 LimitCountDialogue;
    public  bool                Play;
    



    void Start()
    {
        PlayerController    = FindObjectOfType<PlayerController>();
        CountDialogue       = -1;
        LimitCountDialogue  = TypesDialogues.Length;
        StatesCurrent       = EStates.NoTalking;
    }

    void Update()
    {
        Observer();
        switch(TypeBots)
        {


            case ETypeBots.NPCs:
                switch(StatesCurrent)
                {
                    case EStates.NoTalking:

                    if(DistancePlayer <= MinimiumDistance)
                    StatesCurrent = EStates.Talking;

                    break;

                    case EStates.Talking:
                    break;
                }
            break;






            case ETypeBots.Enemies:
            
                switch(StatesCurrent)
                {
                    case EStates.NoTalking:
                        StopCoroutine(StartTalking());
                        TextDialogue.gameObject.SetActive(false);
                        if(DistancePlayer < MinimiumDistance)
                        {
                            StatesCurrent = EStates.Talking;
                        }
                        

                    break;

                    case EStates.Talking:
                    TextDialogue.gameObject.SetActive(true);
                    if(Play){StartCoroutine(StartTalking()); Play = false;}
                    
                    break;
                }
            break;
        }
    }

    // Functions

    void Observer()
    {
        DistancePlayer = Vector2.Distance(transform.position, PlayerController.transform.position);
    }

    IEnumerator StartTalking()
    {
        yield return new WaitForSeconds(3);
        if(CountDialogue != LimitCountDialogue)
        {
            while(true)
            {
                yield return new WaitForSeconds(3);
                CountDialogue += 1;
                TextDialogue.text = TypesDialogues[CountDialogue];
            }
        }else if(CountDialogue >= LimitCountDialogue)
        {
            StatesCurrent = EStates.NoTalking;
        }
    }

    
}
