using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerColisions : MonoBehaviour
{
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Underground"))
        {
            FindObjectOfType<AudioController>().SourceAmbient.pitch = -0.5f;
            FindObjectOfType<AudioController>().SourceAmbient.volume = 0.1f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Underground"))
        {
            FindObjectOfType<AudioController>().SourceAmbient.pitch = 1f;
            FindObjectOfType<AudioController>().SourceAmbient.volume = PlayerPrefs.GetFloat("VolumeMusic");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Underground"))
        {
            FindObjectOfType<AudioController>().SourceAmbient.pitch = -0.5f;
        }
    }

}
