using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        string playerTag = transform.parent.tag;

        if (playerTag == "Player") {

            if (collision.tag == "Player 2")
            {

                collision.GetComponent<PlayerHealth>().takeDamage(20);
            }

        } else if (playerTag == "Player 2") {

            if (collision.tag == "Player")
            {

                collision.GetComponent<PlayerHealth>().takeDamage(20);
            }

        }

        

        
    }
}
