using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]public Transform Target;
    [SerializeField]private float PositionY;
    [SerializeField]private float PositionX;
    [SerializeField]private bool  InStart;

    void Start()
    {
        if(InStart)
        {
            transform.position = new Vector3(Target.transform.position.x + PositionX, 
            Target.transform.position.y + PositionY, 1);
        }
    }

    
    void Update()
    {
        if(!InStart)
        {transform.position = new Vector3(Target.transform.position.x + PositionX, 
        Target.transform.position.y + PositionY, 1);}

        

    }
}
