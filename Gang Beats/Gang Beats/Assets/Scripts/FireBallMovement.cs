using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    public bool isPlayerOne = true;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (isPlayerOne)
        {

            if (other.tag == "Player 2")
            {
                other.GetComponent<PlayerHealth>().takeDamage(7);
                GameObject.Destroy(this.gameObject);
            }
        }
        else
        {

            if (other.tag == "Player")
            {
                other.GetComponent<PlayerHealth>().takeDamage(7);
                GameObject.Destroy(this.gameObject);
            }

        }

        if (other.tag == "ground")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
