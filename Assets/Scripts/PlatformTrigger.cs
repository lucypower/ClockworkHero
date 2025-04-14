using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 0);

            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.m_lastCheckpoint = gameObject;
        }
    }
}
