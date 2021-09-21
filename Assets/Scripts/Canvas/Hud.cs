using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField]private PlayerController PlayerController;
    [SerializeField]private PlayerControllerInputs PlayerControllerInputs;
    [SerializeField]private GameObject             ObjectMenu;
    [SerializeField]public  TextMeshProUGUI TextItem;
    [SerializeField]public  TextMeshProUGUI TextLife;
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
        PlayerControllerInputs = FindObjectOfType<PlayerControllerInputs>();
    }

    
    void Update()
    {
        TextLife.text = Mathf.FloorToInt(PlayerController.Life).ToString();

        if(PlayerControllerInputs.KeyEscape && PlayerControllerInputs.CountClick == 0)
        {OpenMenuInGame();}
        else if(PlayerControllerInputs.KeyEscape && PlayerControllerInputs.CountClick == 1)
        {CloseMenuInGame();}
    }

    void OpenMenuInGame()
    {
        Time.timeScale = 0;
        ObjectMenu.SetActive(true);

        PlayerControllerInputs.CountClick = 1;
    }

    void CloseMenuInGame()
    {
        Time.timeScale = 1;
        ObjectMenu.SetActive(false);
        PlayerControllerInputs.CountClick = 0;
    }

    public void ReceiveItem(string Message, float Value)
    {
        TextItem.text = Message + Value;
        StartCoroutine(DesactiveText());
    }


    IEnumerator DesactiveText()
    {
        yield return new WaitForSeconds(2);
        TextItem.gameObject.SetActive(false);

    }
}
