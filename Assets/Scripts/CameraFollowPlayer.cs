using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform m_player;

    void Update()
    {
        transform.position = new Vector3(m_player.position.x, transform.position.y, transform.position.z);
    }
}
