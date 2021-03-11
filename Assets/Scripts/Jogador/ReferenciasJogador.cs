using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class ReferenciasJogador : MonoBehaviour
{
    [HideInInspector]public Animator anim;
    [HideInInspector]public bool  viradoDireita;
    [HideInInspector]public bool  correndo;
    [HideInInspector]public bool  abrigado; 
    [HideInInspector]public float velocidade;
    [HideInInspector]public int   sequencia;
    [HideInInspector]public  int   vida       = 100;
    public  Image          vidaUI;
    public  Sprite[]       vidasSprite;
}
