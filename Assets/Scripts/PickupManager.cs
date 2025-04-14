using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [HideInInspector] public int m_pickupsCollected;
    [SerializeField] TextMeshProUGUI m_pickupsText;
    [SerializeField] TextMeshProUGUI m_goalText;

    bool m_textChanged;

    private void Update()
    {
        m_pickupsText.text = m_pickupsCollected + " / 3";

        if (m_pickupsCollected == 3 && !m_textChanged)
        {
            m_textChanged = true;
            m_goalText.text = "Return the clock pieces to the clock!";
        }
    }
}
