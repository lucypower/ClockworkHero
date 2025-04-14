using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformPuzzle : MonoBehaviour
{
    [SerializeField] Transform m_platform;
    Gyroscope m_gyro;

    private void Awake()
    {
        m_gyro = GetComponentInParent<Gyroscope>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == m_platform.gameObject)
        {
            m_gyro.m_canPlatformMove = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == m_platform.gameObject)
        {
            m_gyro.m_canPlatformMove = false;
        }
    }
}
