using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    private PlayerController PlayerController;
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        transform.position = new Vector3(PlayerController.transform.position.x,
        transform.position.y, -1);
    }
}
