using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public AudioClip meleeHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string playerTag = transform.parent.tag;

        if (playerTag == "Player") {

            if (collision.tag == "Player 2")
            {
                AudioSource.PlayClipAtPoint(meleeHit, new Vector3(0,0,0), 0.8f);
                collision.GetComponent<PlayerHealth>().takeDamage(20);
            }

        } else if (playerTag == "Player 2") {

            if (collision.tag == "Player")
            {
                AudioSource.PlayClipAtPoint(meleeHit, new Vector3(0, 0, 0), 0.8f);
                collision.GetComponent<PlayerHealth>().takeDamage(20);
            }

        }

        

        
    }
}
