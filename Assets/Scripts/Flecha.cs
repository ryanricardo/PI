using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    private Jogador jogador;
    private Inimigo inimigo_;

    void Start()
    {
        inimigo_ = FindObjectOfType<Inimigo>();
        jogador = FindObjectOfType<Jogador>();
    }

    
    void Update()
    {
        transform.Translate(new Vector2(5 * Time.deltaTime, 0f));
        Invoke("Destruir", 3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            jogador.vida -= 10;
            Destruir();
        }


    }
    
    public void Destruir()
    {
        inimigo_.proxima = true;
        Destroy(gameObject);
    }



}
