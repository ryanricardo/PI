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
    


    [Header("States")]
    public  EStates             StatesCurrent;
    [Header("Components")]
    public  PlayerController    PlayerController;
    public  TextMeshProUGUI     TextDialogue;
    public  GameObject          GameObjectTalk;
    [Header("Atributtes Object")]
    [SerializeField]private string NameObject;
    [Header("Atributtes Distance")]
    public  float               DistancePlayer;
    public  float               MinimiumDistance;
    [Header("Atributtes Dialogues")]
    public  string[]            TypesDialogues;
    public  int                 CountDialogue;
    public  int                 LimitCountDialogue;
    public  float               TimeNextDialogue;
    public  bool                PlayMusic;
    public  bool                StartTalk;
    public  bool                PlayOneTime;
    [Header("Atributtes Audio")]
    [SerializeField]private int Music;
    
    



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

        switch(StatesCurrent)
        {
            case EStates.NoTalking:
                if(PlayOneTime)
                {
                    PlayerController.Dialogue = false; 
                    PlayerController.Moviment = true; 
                    FindObjectOfType<AudioController>().SourceAmbient.volume = PlayerPrefs.GetFloat("VolumeMusic");
                    PlayOneTime = false;
                    }
                TextDialogue.gameObject.SetActive(false);
                if(DistancePlayer <= MinimiumDistance && StartTalk)
                StatesCurrent = EStates.Talking;
            break;

            case EStates.Talking:
                PlayOneTime = true;
                PlayerController.StartDialogue();
                TextDialogue.gameObject.SetActive(true);
                GameObjectTalk.SetActive(false);
                if(StartTalk){StartCoroutine(StartTalking()); StartTalk = false;}
                if(PlayMusic)
                {
                    FindObjectOfType<AudioController>().PlayMusic(Music);
                    FindObjectOfType<AudioController>().SourceAmbient.volume = 0;
                    PlayMusic = false;
                }else if(CountDialogue >= LimitCountDialogue)
                {StatesCurrent = EStates.NoTalking;}
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
            yield return new WaitForSeconds(TimeNextDialogue);
            CountDialogue += 1;
            TextDialogue.text = NameObject + " \n\n" + TypesDialogues[CountDialogue];
        }while(CountDialogue < LimitCountDialogue);

    }

    
}
