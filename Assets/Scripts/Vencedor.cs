using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Vencedor : MonoBehaviour
{

    private Jogador jogador;
    private Hud     hud;
        
    void Start()
    {
        PlayerPrefs.SetString("Vencedor", "");
        hud     = FindObjectOfType<Hud>();
        jogador = FindObjectOfType<Jogador>();
    }

    
    void Update()
    {
        if(jogador.vida <= 0)
        {
            PlayerPrefs.SetString("Vencedor", "perdeu");
            SceneManager.LoadScene("Terminou");
        }

        if(hud.cronometro <= 0)
        {
            PlayerPrefs.SetString("Vencedor", "perdeu");
            SceneManager.LoadScene("Terminou");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetString("Vencedor", "venceu");
            SceneManager.LoadScene("Terminou");
        }
    }
}
