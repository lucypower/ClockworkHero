using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform m_player;
    public float m_offsetY;

    void Update()
    {
        transform.position = new Vector3(m_player.position.x, m_player.position.y + m_offsetY, transform.position.z);
    }
}
