using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFollow : MonoBehaviour
{
    [SerializeField]private float PositionY;
    [SerializeField]private float PositionX;
    [SerializeField]private float SpeedMoveTowards;
    [SerializeField]private PlayerController PlayerController;
  
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }

   
    void Update()
    {
        if(FindObjectOfType<PlayerController>().IsRight == true)
        {PositionX = 3;}
        else if(FindObjectOfType<PlayerController>().IsRight == false)
        {PositionX = -3;}

        Vector2 TargetVector2 = new Vector2
        (PlayerController.transform.position.x + PositionX, PlayerController.transform.position.y);

      
        transform.position = Vector2.MoveTowards
        (transform.position, TargetVector2, 1 * SpeedMoveTowards* Time.deltaTime);
        
    }
}
