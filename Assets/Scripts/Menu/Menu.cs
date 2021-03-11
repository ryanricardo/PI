using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string novaCena;
    public void TrocarCena()
    {
        SceneManager.LoadScene(novaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
