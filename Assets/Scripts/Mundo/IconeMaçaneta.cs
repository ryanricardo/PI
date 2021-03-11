using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconeMaçaneta : MonoBehaviour
{

    public GameObject iconeMaçaneta_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            iconeMaçaneta_.SetActive(true);
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            iconeMaçaneta_.SetActive(false);
        }
    }
}
