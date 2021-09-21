using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private PlayerControllerInputs PlayerControllerInputs;
    [SerializeField]private PlayerController PlayerController;
    [SerializeField]private Animator         Animator;
    [SerializeField]private GameObject       ItemPickup;
    [SerializeField]private GameObject       HandIcon;
    [Header("Atributtes Chest")]
    [SerializeField]private bool             OneTime;
    [SerializeField]private float            PositionSpawnItem;
    

    void Start()
    {
        OneTime          = true;
        PlayerControllerInputs = FindObjectOfType<PlayerControllerInputs>();
        PlayerController = FindObjectOfType<PlayerController>();
        Animator         = GetComponent<Animator>();
    }

    
    void Update()
    {
        float DistancePlayer = Vector2.Distance(transform.position, PlayerController.transform.position);

        if(DistancePlayer <= 2 && PlayerControllerInputs.KeyE && OneTime)
        {
            HandIcon.SetActive(false);
            Animator.SetTrigger("Open");
            Vector2 SpawnPickup = new Vector2(transform.position.x, transform.position.y + PositionSpawnItem);
            Instantiate(ItemPickup, SpawnPickup, Quaternion.identity);
            OneTime = false;
        }
    }
}
