using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [Header("Variables")]
    private Vector3             Direction;
    public  float               Number;
    public  float               Speed;
    public  float               Height;
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
        TransformPlayerController.transform.position.y + Height, -1);

        if(Input.GetKey(KeyCode.A) && Number >= -5)
        {
            Number -= Speed * Time.deltaTime;
            
        }else 
        {
            if(Input.GetKey(KeyCode.D) && Number <= 5)
            {
                
                Number += Speed * Time.deltaTime;
                
            }
        }

        
        
    }
}
