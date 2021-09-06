using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public HudManager hudManager;
    public float walkSpeed;
    public Transform leftWall;
    public Transform rightWall;

    private Stats m_Stats;

    private void Awake()
    {
        m_Stats = GetComponent<Stats>();
        hudManager.UpdateHealthText(m_Stats.health);
    }

    void Update()
    {
        if (m_Stats.health <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalPos = transform.position.x + horizontalInput * walkSpeed * Time.deltaTime;

        float playerSize = transform.localScale.x / 2;

        if (horizontalPos - playerSize <= leftWall.position.x + leftWall.localScale.x / 2) return;
        if (horizontalPos + playerSize >= rightWall.position.x - rightWall.localScale.x / 2) return;  

        transform.position = new Vector3(
            horizontalPos,
            1,
            transform.position.z);
    }

    public void ReceiveDamage(float damage)
    {
        m_Stats.UpdateHealth(-damage);
        hudManager.UpdateHealthText(m_Stats.health);

    }

    public void ReceiveScore(float score)
    {
        m_Stats.UpdateScore(score);
        hudManager.UpdateScoreText(m_Stats.score);
    }

    public void ReceiveHealth(float health)
    {
        m_Stats.UpdateHealth(health);
        hudManager.UpdateHealthText(m_Stats.health);
    }

}
