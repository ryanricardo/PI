using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public GameObject flecha;
    public GameObject spawn;
    public bool   proxima;

    void Start()
    {
        proxima = true;
    }

  
    void Update()
    {
        Ray r = new Ray();
        r.origin = spawn.transform.position;
        r.direction = spawn.transform.right;
        if(Physics2D.Raycast(r.origin, r.direction, 10) && proxima)
        {
            Instantiate(flecha, spawn.transform.position, spawn.transform.rotation);  
            proxima = false;
      
        }
        Debug.DrawLine(r.origin, r.origin + (r.direction * 10), Color.magenta);
    }




}
