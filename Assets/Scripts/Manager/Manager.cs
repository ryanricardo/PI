using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    
    private     Enemie              Enemie;
    private     PlayerController    PlayerController;
    public      GameObject          Boss;
    private     bool                pass;
    [SerializeField]private     BoxCollider2D       Victory;

    void Start()
    {
        pass                = false;
        Enemie              =   FindObjectOfType<Enemie>();    
        PlayerController    =   FindObjectOfType<PlayerController>();
    }

   
    void Update()
    {
        pass = Boss.GetComponent<Enemie>().BossDeath ? true : false;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") == Victory && pass)
        {
           SceneManager.LoadScene("Win");
        }
    }
}
