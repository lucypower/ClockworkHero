using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] GameObject m_clockHands;
    [SerializeField] TextMeshProUGUI m_goalsText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupManager pickupManager = other.GetComponent<PickupManager>();

            if (pickupManager.m_pickupsCollected == 3)
            {
                m_clockHands.SetActive(true);

                m_goalsText.text = "You completed the level!";
            }
        }
    }
}
