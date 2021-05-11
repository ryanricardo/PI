using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morrer : MonoBehaviour
{
    

    private Jogador jogador;
    private Hud     hud;
   
    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
        hud     = FindObjectOfType<Hud>();
    }

    
    void Update()
    {
        if(jogador.vida <= 0)
        {
            PlayerPrefs.SetString("Vencedor", "perdeu");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hud.cronometro = 31;
            jogador.transform.position = new Vector2(-15.53f, -2.11f);
            jogador.vida -= 20;
        }
    }
}
