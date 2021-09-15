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
    public  GameObject          GameObjectTalk;
    [Header("Atributtes Distance")]
    public  float               DistancePlayer;
    public  float               MinimiumDistance;
    [Header("Atributtes Dialogues")]
    public  string[]            TypesDialogues;
    public  int                 CountDialogue;
    public  int                 LimitCountDialogue;
    public  bool                Play;
    public  bool                StartTalk;
    



    void Start()
    {
        PlayerController    = FindObjectOfType<PlayerController>();
        CountDialogue       = -1;
        LimitCountDialogue  = TypesDialogues.Length;
        StatesCurrent       = EStates.NoTalking;
        GameObjectTalk.SetActive(true);
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
                        TextDialogue.gameObject.SetActive(false);
                        if(DistancePlayer <= MinimiumDistance && StartTalk)
                        StatesCurrent = EStates.Talking;

                    break;

                    case EStates.Talking:
                        TextDialogue.gameObject.SetActive(true);
                        GameObjectTalk.SetActive(false);
                        if(StartTalk){StartCoroutine(StartTalking()); StartTalk = false;}
                        if(Play){FindObjectOfType<AudioController>().PlayMusic(0); Play = false;
                        }else if(CountDialogue >= LimitCountDialogue)
                        {StatesCurrent = EStates.NoTalking;}
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
                        if(StartTalk){StartCoroutine(StartTalking()); StartTalk = false;}
                        if(Play){FindObjectOfType<AudioController>().PlayMusic(0); Play = false;}
                    
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
        do
        {
            yield return new WaitForSeconds(3);
            CountDialogue += 1;
            TextDialogue.text = TypesDialogues[CountDialogue];
        }while(CountDialogue < LimitCountDialogue);

    }

    
}
