using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController4 : NewPlayerController
{
    public GameObject attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.setMaxHealth(90);
        playerHealth.GameStart();

        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Attack1Start()
    {

        attackCollider.SetActive(true);

    }

    void Attack1End()
    {

        attackCollider.SetActive(false);


    }

}
