using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public float m_rotationMultiplier;

    Vector3 m_rotation;
    [HideInInspector] public bool m_playerInPosition;
    public Transform m_player;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        if (m_playerInPosition)
        {
            m_rotation.z = Input.gyro.rotationRateUnbiased.z * m_rotationMultiplier;

            transform.Rotate(m_rotation);
        }
    }
}
