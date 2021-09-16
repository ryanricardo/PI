using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Components")]
    public BoxCollider2D TriggerMusic;
    [Header("Atributtes AudioController")]
    public  AudioSource SourceMusic;
    public  AudioSource SourceAmbient;
    
    public  AudioClip[] ClipsMusics;
    public  AudioClip[] ClipsAmbients;

    public  bool[]    Play;
    
    void Start()
    {
       for(int i = 0; i < Play.Length; i++)
       {
           Play[i] = true;
       }
    }


    void Update()
    {
        
    }

    void PlayAmbient(int countClipsAmbients)
    {
        
        SourceAmbient.clip = ClipsAmbients[countClipsAmbients];
        if(Play[0])
        {
            SourceAmbient.Play();
            Play[0] = false;
        }
    }

    public void PlayMusic(int countClipsMusic)
    {
        SourceMusic.clip = ClipsMusics[countClipsMusic];
        if(Play[1])
        {
            SourceMusic.Play();
            Play[1] = false;
        }
    }


}
