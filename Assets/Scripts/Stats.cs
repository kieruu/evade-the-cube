using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float score;

    private float maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

    public void UpdateHealth(float value)
    {
        if(health + value > maxHealth)
        {
            health = maxHealth;
            return;
        }
        health += value;
    }

    public void UpdateScore(float score)
    {
        this.score += score;
    }
}
