using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    private PlayerMenu PlayerMenu;
    void Start()
    {
        PlayerMenu = FindObjectOfType<PlayerMenu>();
    }

    
    void Update()
    {
        
    }

    public void UpdateEntrar()
    {
        StartCoroutine(LoadScene());
        PlayerMenu.Move();
    }

    public void UpdateSair()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Scene 0");
    }
}
