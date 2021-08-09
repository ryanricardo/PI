using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    
    private     Enemie              Enemie;
    private     PlayerController    PlayerController;

    void Start()
    {
        Enemie              =   FindObjectOfType<Enemie>();    
        PlayerController    =   FindObjectOfType<PlayerController>();
    }

   
    void Update()
    {
        if(PlayerController.Life <= 0)
        {
            StartCoroutine(PlayerDeath(3));
        }
    }

    // Functions

    IEnumerator PlayerDeath(float time)
    {
        Enemie.CurrentStates = "Empty";
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Loose");
    }
}
