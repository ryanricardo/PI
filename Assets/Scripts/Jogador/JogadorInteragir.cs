using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorInteragir : MonoBehaviour
{    
    [HideInInspector] public bool abrirPorta;
    [HideInInspector] public bool lerLivro; 
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            abrirPorta = true;
            lerLivro   = true;
        } else 
        {
            lerLivro   = false;
            abrirPorta = false;
        }
    }

}
