using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupManager pickupManager = other.GetComponent<PickupManager>();

            pickupManager.m_pickupsCollected++;

            Destroy(gameObject);
        }
    }
}
