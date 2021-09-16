using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMusic : MonoBehaviour
{
    [SerializeField]private AudioController audioController;
    [SerializeField]private int             NumberMusic;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !audioController.SourceMusic.isPlaying)
        {
            audioController.Play[1] = true;
            audioController.PlayMusic(NumberMusic);
        }
    }
}
