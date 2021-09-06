using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{

    public float walkSpeed;
    public float healthValue;

    private float m_ThresholdPositionZ = -10.0f;
    private PlayerController m_PC;

    // Start is called before the first frame update
    void Start()
    {
        m_PC = GameObject
            .Find("Player")
            .GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - walkSpeed * Time.deltaTime);

        // distance between player and enemies
        float totalDistance = Vector3.Distance(m_PC.transform.position, transform.position);

        if (totalDistance < 1.0f)
        {
            m_PC.ReceiveHealth(healthValue);
            Destroy(gameObject);
        }
        else if (transform.position.z <= m_ThresholdPositionZ)
        {
            Destroy(gameObject);
        }
    }
}
