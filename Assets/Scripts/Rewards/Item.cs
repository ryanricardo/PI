using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum TypeItem
    {
        JumpMore,
    }

    [SerializeField]private TypeItem typeItem;
    [SerializeField]private float    ValueReward;


    
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            switch(typeItem)
            {
                case TypeItem.JumpMore:
                FindObjectOfType<PlayerController>().ForceJump += ValueReward;
                FindObjectOfType<Hud>().ReceiveItem("Jump + " , ValueReward);
                Destroy(gameObject, 0);
                break;
            }
        }
    }
}

