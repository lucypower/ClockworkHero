using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    Vector3 m_rotation;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        m_rotation.z = Input.gyro.rotationRateUnbiased.z;

        transform.Rotate(m_rotation);
    }
}
