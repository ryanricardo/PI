using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]private Transform Target;
    [SerializeField]private float PositionY;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(Target.transform.position.x, 
        PositionY, 1);
    }
}
