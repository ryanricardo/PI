using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [Header("Variables")]
    public  float               Height;
    public  float               Largure;
    [Header("Components")]
    public  Camera              Camera;
    private PlayerController    PlayerController;
    private Transform           TransformPlayerController;

    


    void Start()
    {
        PlayerController            = FindObjectOfType<PlayerController>();
        TransformPlayerController   = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        transform.position = new Vector3(PlayerController.transform.position.x + Largure, 
        TransformPlayerController.transform.position.y + Height, -1);

        if(Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.orthographicSize >= 5){Camera.orthographicSize -= 1;}
        if(Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.orthographicSize <= 7){Camera.orthographicSize += 1;}
    }
}
