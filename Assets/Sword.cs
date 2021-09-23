using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    enum TypeUserSword
    {
        Enemy,
        Player,
    }

    [SerializeField]private TypeUserSword       typeUserSword;
    [SerializeField]private Enemie              Enemie;
    [SerializeField]private PlayerController    PlayerController;
    [SerializeField]private Animator            AnimatorPlayer;
    [SerializeField]private Animator            AnimatorEnemie;

    void Start()
    {
        Enemie = FindObjectOfType<Enemie>();
        PlayerController = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(typeUserSword)
        {
            case TypeUserSword.Player:
            if(other.gameObject.CompareTag("Enemie"))
            {
                Debug.Log("Acertou!");
                Enemie.Hit(PlayerController.Damage);
            }
            break;

            case TypeUserSword.Enemy:
            if(other.gameObject.CompareTag("Player") && AnimatorEnemie.GetInteger("Animation") == 4)
            {
                PlayerController.Hit(Enemie.Damage);
            }
            break;
        }
    }
}
