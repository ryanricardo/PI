using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    private bool  viradoDireita;
    public float  velocidade;
    void Start()
    {
        viradoDireita = true;
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
    void OnTriggerEnter2D (Collider2D other)
    {

        if(other.gameObject.CompareTag("Volta") && viradoDireita)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            viradoDireita = false;

        } else if (other.gameObject.CompareTag("Volta") && !viradoDireita)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            viradoDireita = true;
        }

    }

}