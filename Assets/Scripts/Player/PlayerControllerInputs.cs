using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInputs : MonoBehaviour
{
    [SerializeField]public bool  KeySpace;
    [SerializeField]public bool  KeyE;
    [SerializeField]public bool  Mouse0;
    [SerializeField]public bool  Mouse1;
    [SerializeField]public float AxisHorizontal;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){KeySpace = true;}else{KeySpace = false;}
        if(Input.GetKey(KeyCode.E)){KeyE = true;}else{KeyE = false;}
        if(Input.GetMouseButtonDown(0)){Mouse0 = true;}else{Mouse0 = false;}
        if(Input.GetMouseButton(1)){Mouse1 = true;}else{Mouse1 = false;}
        AxisHorizontal = Input.GetAxis("Horizontal");
    }
}
