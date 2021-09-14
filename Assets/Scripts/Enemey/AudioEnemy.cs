using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnemy : MonoBehaviour
{
    
    [Header("Atributtes Actions")]
    [SerializeField]private bool PlayThisCharacter;

    void Start()
    {
        
    }

    
    void Update()
    {
        CheckPlayMusic();
    }

    void CheckPlayMusic()
    {
        float DistancePlayer = Vector2.Distance(transform.position, 
        FindObjectOfType<PlayerController>().transform.position);

        if(PlayThisCharacter && DistancePlayer <= 10)
        {
            FindObjectOfType<AudioController>().PlayMusic(1);
        }
    }
}
