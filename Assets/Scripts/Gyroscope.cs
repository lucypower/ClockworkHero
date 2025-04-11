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

    Vector3 m_rotation;
    [HideInInspector] public bool m_canRotate;

    [Category ("Focus Mechanic")]
    MeshRenderer m_renderer;
    public Material[] m_material;

    [Category("Puzzle")]
    public bool m_isPuzzle;
    public Gyroscope[] m_gyroscopes;
    int m_siblingIndex;

    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();

        Input.gyro.enabled = true;

        if (m_isPuzzle)
        {
            m_gyroscopes = transform.parent.GetComponentsInChildren<Gyroscope>();
            m_siblingIndex = GetIndex(this);
        }
    }

    private void Update()
    {
        if (m_canRotate)
        {
            if (m_renderer.material != m_material[1])
            {
                m_renderer.material = m_material[1];
            }

            if (!m_isPuzzle)
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
        }
        else
        {
            if (m_renderer.material != m_material[0])
            {
                m_renderer.material = m_material[0];
            }
        }

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
        }
    }

    int GetIndex(Gyroscope gear)
    {
        int index = gear.transform.GetSiblingIndex();
        index %= 2;

        return index;
    }

    bool IsOddEven(int gearIndex)
    {
         return gearIndex % 2 == 0;
    }
}
