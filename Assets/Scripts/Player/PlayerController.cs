using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]public float AxisHorizontal;
    [HideInInspector]public RaycastHit2D CheckGround;
    [HideInInspector]public Rigidbody2D rb2;
    private bool             Right;

    public Transform           TransformCheckGround;

    void Start()
    {
        Right = false;
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Variables();
        Movimentation();
    }

    void Movimentation()
    {
        rb2.velocity = new Vector2(AxisHorizontal * 5, rb2.velocity.y);

        if(AxisHorizontal > 0 && !Right)
        {
            Flip();
            Right = true;
        }else if(AxisHorizontal < 0 && Right) 
        {
            Flip();
            Right = false;
        }
    }

    void Variables()
    {
        AxisHorizontal = Input.GetAxis("Horizontal");

        CheckGround = Physics2D.Linecast(transform.position, 
        TransformCheckGround.transform.position, 1 << LayerMask.NameToLayer("Ground"));

    }



    void Flip()
    {
        Vector2 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;

    }
}
