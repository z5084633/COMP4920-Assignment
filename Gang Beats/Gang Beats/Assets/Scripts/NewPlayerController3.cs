using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController3 : NewPlayerController
{
    // Start is called before the first frame update

    public GameObject fireBallSpawn;
    public GameObject fireBall;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.setMaxHealth(80);
        playerHealth.GameStart();
        rb = GetComponent<Rigidbody2D>();
    }


    void Attack1Start()
    {

        GameObject SpawnedFireBall = Instantiate(fireBall, fireBallSpawn.transform.position, gameObject.transform.rotation);

        if (playerOne)
        {
            SpawnedFireBall.GetComponent<FireBallMovement>().isPlayerOne = true;
        }
        else
        {
            SpawnedFireBall.GetComponent<FireBallMovement>().isPlayerOne = false;
        }

        if (gameObject.transform.localScale.x < 0)
        {
            SpawnedFireBall.transform.Rotate(new Vector3(0, 180, 0));
            SpawnedFireBall.GetComponent<Rigidbody2D>().velocity = Vector2.left * 15;
        }
        else
        {
            SpawnedFireBall.GetComponent<Rigidbody2D>().velocity = Vector2.right * 15;
        }


    }

}
