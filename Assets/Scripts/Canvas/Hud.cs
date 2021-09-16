using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    [SerializeField]private PlayerController PlayerController;
    public TextMeshProUGUI TextItem;
    public TextMeshProUGUI TextLife;
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        TextLife.text = Mathf.FloorToInt(PlayerController.Life).ToString();
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
