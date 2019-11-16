using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heathbar : MonoBehaviour
{

    GameObject player;
    Image bar;
    public bool isForPlayerOne;
    PlayerHealth Health2;
    PlayerHealth Health1;

    // Start is called before the first frame update
    void Start()
    {

        bar = GetComponent<Image>();
        if (isForPlayerOne)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Health1 = player.GetComponent<PlayerHealth>();
        }
        else { 
            player = GameObject.FindGameObjectWithTag("Player 2");
            Health2 = player.GetComponent<PlayerHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (isForPlayerOne)
        {
            bar.fillAmount = (float)Health1.getHealth() / (float)Health1.getMaxHealth();
        }
        else {
            bar.fillAmount = (float)Health2.getHealth() / (float)Health2.getMaxHealth();
        }

    }
}
