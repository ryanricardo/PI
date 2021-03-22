using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroInimigo : MonoBehaviour
{
    Rigidbody2D rb2;
    private float vida;
    void Start()
    {
        vida = 100;
        rb2  = GetComponent<Rigidbody2D>();
    }
    public void TomarDano(int dan)
    {
        vida -= dan;
        Debug.Log("Estou com " + vida + " de vida");
    }
}
