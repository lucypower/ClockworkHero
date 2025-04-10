using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    Gyroscope m_gyro;
    public ButtonMovement m_playerMovement;

    private void Awake()
    {
        m_gyro = GetComponentInParent<Gyroscope>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player In Position");

            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Out Position");

            other.gameObject.transform.parent = null;            
        }
    }
}
