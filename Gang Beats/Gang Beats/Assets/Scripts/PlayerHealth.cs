using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int health = 1;

    public void setMaxHealth(int maxHealth) {
        this.maxHealth = maxHealth;
    }

    public int getHealth() {
        return health;
    }

    public void addHealth(int amount) {
        health += amount;
    }
    public int getMaxHealth() {
        return maxHealth;
    }
    public void GameStart() {
        health = maxHealth;
    }

    public void takeDamage(int amount) {
        health -= amount;
    }

}
