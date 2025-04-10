using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public float m_rotationMultiplier;

    Vector3 m_rotation;
    [HideInInspector] public bool m_playerInPosition;

    MeshRenderer m_renderer;
    public Material[] m_material;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();

        Input.gyro.enabled = true;
    }

    private void Update()
    {
        if (m_playerInPosition)
        {
            m_rotation.z = Input.gyro.rotationRateUnbiased.z * m_rotationMultiplier;

            transform.Rotate(m_rotation);

            if (m_renderer.material != m_material[1])
            {
                m_renderer.material = m_material[1];
            }
        }
        else
        {
            if (m_renderer.material != m_material[0])
            {
                m_renderer.material = m_material[0];
            }
        }
    }
}
