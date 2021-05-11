using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarVencedor : MonoBehaviour
{
    public GameObject[] estadoTerminou;
    void Start()
    {
        
    }

    
    void Update()
    {
        string estado = PlayerPrefs.GetString("Vencedor");

        if(estado == "venceu")
        {
            estadoTerminou[0].SetActive(true);
        } else if(estado == "perdeu")
        {
            estadoTerminou[1].SetActive(true);
        }
    }
}
