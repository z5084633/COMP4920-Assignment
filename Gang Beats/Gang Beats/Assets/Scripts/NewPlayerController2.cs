using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController2 : NewPlayerController
{

    public GameObject bullet;
    public GameObject bulletSpawnLoaction;



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.setMaxHealth(120);
        playerHealth.GameStart();
        rb = GetComponent<Rigidbody2D>();
    }

    

    void Attack1Start()
    {

        GameObject Spawnedbullet = Instantiate(bullet, bulletSpawnLoaction.transform.position, gameObject.transform.rotation);

        if (playerOne) {
            Spawnedbullet.GetComponent<bulletmovement>().isPlayerOne = true;
        }
        else {
            Spawnedbullet.GetComponent<bulletmovement>().isPlayerOne = false;
        }

        Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;

        if (gameObject.transform.localScale.x < 0)
        {
            Spawnedbullet.transform.Rotate(new Vector3(0, 180, 0));
            Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
        }
        else {
            Spawnedbullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
        }


    }
    void Attack1End()
    {
    }
}
