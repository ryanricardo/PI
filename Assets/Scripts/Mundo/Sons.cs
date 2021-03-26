using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sons : MonoBehaviour
{
    
    public  AudioSource som;
    private Jogador     jogador_;
    
    private void Start()
    {
        jogador_ = FindObjectOfType<Jogador>();
        som      = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(jogador_.abrigado)
        {
            som.pitch = 0.3f;
        } else if(jogador_.abrigado == false)
        {
            som.pitch = 1f;
        }
    }



}
