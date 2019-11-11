using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

 
        if (other.tag == "Player") { //change to add other players

            other.GetComponent<NewPlayerController>().takeDamage(10);
            GameObject.Destroy(this.gameObject);
        }

        if (other.tag == "ground") {
            GameObject.Destroy(this.gameObject);
        }
    }
}
