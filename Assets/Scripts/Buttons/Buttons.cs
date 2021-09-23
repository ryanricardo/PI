using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour
{

    [SerializeField]private PlayerMenu PlayerMenu;
    [SerializeField]private TextMeshProUGUI TextButtonEntrar;
    [SerializeField]private GameObject      ImageHUD;
    [SerializeField]private int             SceneCount;
   
    
    void Start()
    {
        PlayerMenu = FindObjectOfType<PlayerMenu>();
    }

    
    void Update()
    {
        SceneCount = SceneManager.sceneCount;
        if(PlayerMenu.transform.position.x == PlayerMenu.NewPosition.x)
        {SceneManager.LoadScene("Scene 0"); Destroy(PlayerMenu.gameObject);}
    }

    public void UpdateExitMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateExitGame()
    {
        Application.Quit();
    }

    public void UpdateEntrarMenu()
    {
        PlayerMenu.Move();
        StartCoroutine(StartLoading());


    }

    public void UpdateEntrar()
    {
        SceneManager.LoadScene("Scene 0");


    }

    public void UpdateSair()
    {
        Application.Quit();
    }

    public void UpdateOptions()
    {
        ImageHUD.SetActive(true);
    }
    public void UpdateExitOptions()
    {
        ImageHUD.SetActive(false);
    }

    IEnumerator StartLoading()
    {
        do
        {
            yield return new WaitForSeconds(0.5f);
            TextButtonEntrar.text = "Loading.";
            yield return new WaitForSeconds(0.5f);
            TextButtonEntrar.text = "Loading..";
            yield return new WaitForSeconds(0.5f);
            TextButtonEntrar.text = "Loading...";
        }while(SceneManager.sceneCount == 1);

    }

}
