using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2;
    
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float AxisHorizontal = Input.GetAxis("Horizontal");

        rb2.velocity = new Vector2(AxisHorizontal * 10, rb2.velocity.y);
        
    }
}
