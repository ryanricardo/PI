using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [Header("Variables")]
    private Vector3             Direction;
    public  float               Number;
    [Header("Components")]
    private PlayerController    PlayerController;
    private Transform           TransformPlayerController;

    


    void Start()
    {
        PlayerController            = FindObjectOfType<PlayerController>();
        TransformPlayerController   = FindObjectOfType<PlayerController>().transform;
    }

    
    void Update()
    {
        transform.position = new Vector3(PlayerController.transform.position.x + Number, 
        transform.position.y, -1);

        if(Input.GetKey(KeyCode.A))
        {
            
            Number = -5;
            
        }else 
        {
            if(Input.GetKey(KeyCode.D))
            {
                
                Number = 5;
                
            }
        }

        
    }
}
