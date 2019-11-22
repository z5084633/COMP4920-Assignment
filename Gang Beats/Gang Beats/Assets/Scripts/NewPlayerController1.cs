using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController1 : NewPlayerController
{

    public GameObject attackCollider;
    public AudioClip axeSwing;
    public AudioClip Jump;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerHealth.setMaxHealth(120);
        playerHealth.GameStart();

        attackCollider.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    
    public override void PlayJumpSound() {
        AudioSource.PlayClipAtPoint(Jump, new Vector3());
    }

    void Attack1Start()
    {
        AudioSource.PlayClipAtPoint(axeSwing, new Vector3(0, 0, 0));
        attackCollider.SetActive(true);

    }

    void Attack1End()
    {

        attackCollider.SetActive(false);

    }

}
