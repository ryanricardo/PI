using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPorta : MonoBehaviour
{
    public GameObject Jogador;
    public GameObject Porta;
    void Update()
    {
        if(Porta.GetComponent<Porta>().colidio && Jogador.GetComponent<JogadorInteragir>().abrirPorta)
        {
            GetComponent<Collider2D>().isTrigger = true;

        } else if (Porta.GetComponent<Porta>().colidio == false)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
