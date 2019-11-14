using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            collision.GetComponent<NewPlayerController>().takeDamage(20);
        }

        
    }
}
