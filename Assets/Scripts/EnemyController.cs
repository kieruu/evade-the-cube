using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float walkSpeed;
    public float enemyDamage;

    private float m_ThresholdPositionZ = -10.0f;
    private PlayerController m_PC;

    private void Start()
    {
        m_PC = GameObject
            .Find("Player")
            .GetComponent<PlayerController>();
    }

    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - walkSpeed * Time.deltaTime);


        // distance between player and enemies
        float totalDistance = Vector3.Distance(m_PC.transform.position, transform.position);
       
        if (totalDistance < 1.0f)
        {
            m_PC.ReceiveDamage();
            Destroy(gameObject);
        }
        else if (transform.position.z <= m_ThresholdPositionZ)
        {
            Destroy(gameObject);
        }

    }
}