using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pilar : MonoBehaviour
{

    private SpriteRenderer spriteR;
    public Sprite[] formasPilar;
    private void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spriteR.sprite = formasPilar[0];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            spriteR.sprite = formasPilar[1];
        }
    }

}
