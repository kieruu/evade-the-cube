using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Text health; 
    public Text Score;

    public void UpdateHealthText(float health)
    {
        this.health.text = "Health: "+ health;
    }

    public void UpdateScoreText(float score)
    {
        this.Score.text = "Score: " + score;
    }
}
