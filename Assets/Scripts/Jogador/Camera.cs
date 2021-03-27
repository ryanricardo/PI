using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public  Transform jogador;
    public  float direcaoCameraX;
    public  float direcaoCameraY;
    private float cameraNova;

    
    void Update()
    {
        Vector3 cameraNova = new Vector3(jogador.transform.position.x + direcaoCameraX, jogador.transform.position.y + direcaoCameraY, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, cameraNova, 5 * Time.deltaTime);
    }
}
