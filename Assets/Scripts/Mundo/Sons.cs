using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sons : MonoBehaviour
{
    
    public AudioSource som;
    public GameObject  Jogador;
    
    private void Start()
    {
        som = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if(Jogador.GetComponent<Jogador>().abrigado)
        {
            
        }

        if(Jogador.GetComponent<Jogador>().abrigado)
        {
            som.pitch = 0.3f;
        } else if(Jogador.GetComponent<Jogador>().abrigado == false)
        {
            som.pitch = 1f;
        }
    }



}
