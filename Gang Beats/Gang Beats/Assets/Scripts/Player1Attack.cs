using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player 2") {

            collision.GetComponent<NewPlayerController2>().takeDamage(20);

        }
    }
}
