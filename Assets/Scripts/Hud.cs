using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text texto;
    private  Slider slider;
    [HideInInspector]public float cronometro;
    private Jogador jogador;
    private bool comeca;
    public  AudioSource musicao;
    private Lobo lobo;
    public Text corra;

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
        slider = FindObjectOfType<Slider>();
        comeca = false;
        lobo = FindObjectOfType<Lobo>();
        cronometro = 31f;
    }

    private void Update() 
    {
        if(comeca)
        {
            cronometro -= Time.deltaTime;
            texto.text =  cronometro.ToString();
        }

        slider.value = jogador.vida;
    }
    public void AtivaTempo()
    {
        comeca = true;
        musicao.Play();
    }

    public void DesativaTempo()
    {
        comeca = false;
    }


    
}
