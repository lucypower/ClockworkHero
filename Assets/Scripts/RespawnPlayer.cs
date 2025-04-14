using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] PlayerMovement m_player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        m_player.transform.position = m_player.m_lastCheckpoint.transform.position;
    }    
}
