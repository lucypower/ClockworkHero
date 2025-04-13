using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    Vector3 m_rotation;
    void Update()
    {
        m_rotation.y = 200 * Time.deltaTime;

        transform.Rotate(m_rotation);
    }
}
