using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]private Transform Target;
    [SerializeField]private float PositionY;
    [SerializeField]private float PositionX;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x + PositionX, 
        PositionY, 1);
    }
}
