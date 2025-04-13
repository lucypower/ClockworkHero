using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public bool m_debugRotation;
    public bool m_debugReverse;
    public float m_rotationMultiplier;

    [Header("GyroMechanic")]
    Vector3 m_rotation;
    [HideInInspector] public bool m_canRotate;

    [Header("FocusMechanic")]
    [SerializeField] Material[] m_material;
    MeshRenderer m_renderer;

    [Header("Puzzle")]
    [SerializeField] bool m_isVerticalPuzzle;
    [SerializeField] bool m_isPlatformPuzzle;
    [SerializeField] Transform m_platform;
    [HideInInspector] public bool m_canPlatformMove;
    Gyroscope[] m_gyroscopes;
    int m_siblingIndex;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();

        Input.gyro.enabled = true;

        if (m_isVerticalPuzzle)
        {
            m_gyroscopes = transform.parent.GetComponentsInChildren<Gyroscope>();
            m_siblingIndex = GetIndex(this);
        }
    }

    private void Update()
    {
        if (m_debugRotation)
        {
            m_rotation.z = 1 * m_rotationMultiplier * Time.deltaTime;

            if (m_debugReverse)
            {
                transform.Rotate(m_rotation);
            }
            else
            {
                transform.Rotate(-m_rotation);
            }

            return;
        }

        if (m_canRotate)
        {
            if (m_renderer.material != m_material[1])
            {
                m_renderer.material = m_material[1];
            }

            if (!m_isVerticalPuzzle)
            {
                m_rotation.z = Input.gyro.rotationRateUnbiased.z * m_rotationMultiplier;

                transform.Rotate(m_rotation);
            }
            else
            {
                foreach (Gyroscope gear in m_gyroscopes)
                {
                    int index = GetIndex(gear);

                    gear.m_rotation.z = Input.gyro.rotationRateUnbiased.z * m_rotationMultiplier;
                    
                    Debug.Log(index);

                    if (index == m_siblingIndex)
                    {
                        gear.transform.Rotate(m_rotation);
                    }
                    else
                    {
                        gear.transform.Rotate(-m_rotation);
                    }
                }
            }

            if (m_isPlatformPuzzle)
            {
                if (m_canPlatformMove)
                {
                    m_platform.position = new Vector3(m_platform.position.x - Input.gyro.rotationRateUnbiased.z, m_platform.position.y, m_platform.position.z);
                    //if (Input.gyro.rotationRateUnbiased.z > 0)
                    //{
                    //    MovePlatform(-1);
                    //}
                    //else
                    //{
                    //    MovePlatform(1);
                    //}
                }
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

    int GetIndex(Gyroscope gear)
    {
        int index = gear.transform.GetSiblingIndex();
        index %= 2;

        return index;
    }

    void MovePlatform(int direction)
    {
        m_platform.position = new Vector3(m_platform.position.x + (0.1f * direction), 0, 0);
    }
}
