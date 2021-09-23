using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMusic : MonoBehaviour
{
    [SerializeField]private AudioController audioController;
    [SerializeField]private int             NumberMusic;
    [SerializeField]private bool            PlayMusic;
    [SerializeField]private bool            BlockWay;
    [SerializeField]private float           TimeBlockWay;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && PlayMusic)
        {
            audioController.Play[1] = true;
            audioController.PlayMusic(NumberMusic);
        }

        if(other.gameObject.CompareTag("Player") && BlockWay)
        {
            StartCoroutine(BlockWayWithCollision(TimeBlockWay));
        }
    }

    IEnumerator BlockWayWithCollision(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
