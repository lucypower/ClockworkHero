using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody m_rigidbody;

    bool leftPressed, rightPressed, focusPressed, jumpPressed;
    public float m_speed, m_jumpForce;

    GameObject[] m_gears;
    Gyroscope m_gyro;

    [HideInInspector] public GameObject m_lastCheckpoint;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        

        m_gears = GameObject.FindGameObjectsWithTag("Gear");
    }

    private void FixedUpdate()
    {
        if (leftPressed && !rightPressed)
        {
            m_rigidbody.velocity = new Vector3(-1 * m_speed, m_rigidbody.velocity.y, 0);
        }
        else if (rightPressed && !leftPressed)
        {
            m_rigidbody.velocity = new Vector3(1 * m_speed, m_rigidbody.velocity.y, 0);
        }
        else
        {
            m_rigidbody.velocity = new Vector3(0, m_rigidbody.velocity.y, 0);
        }

        if (jumpPressed)
        {
            jumpPressed = false;

            if (-0.5f <= m_rigidbody.velocity.y && m_rigidbody.velocity.y <= 0.5f)
            {
                m_rigidbody.AddForce(new Vector3(0, 1 * m_jumpForce, 0), ForceMode.Impulse);
            }            
        }

        transform.rotation = Quaternion.identity;
    }

    public void MoveLeft()
    {
        if (!leftPressed)
        {
            leftPressed = true;
        }
        else
        {
            leftPressed = false;
        }
    }

    public void MoveRight()
    {
        if (!rightPressed)
        {
            rightPressed = true;
        }            
        else
        {
            rightPressed = false;
        }
    }

    public void FocusOnGear()
    {
        if (!focusPressed)
        {
            focusPressed = true;

            GameObject nearestGear = null;
            float distance = Mathf.Infinity;

            foreach (GameObject gear in m_gears)
            {
                Vector3 difference = gear.transform.position - transform.position;
                float currentDistance = difference.sqrMagnitude;

                if (currentDistance < distance)
                {
                    nearestGear = gear;
                    distance = currentDistance;
                }
            }

            m_gyro = nearestGear.GetComponent<Gyroscope>();
            m_gyro.m_canRotate = true;
        }
        else
        {
            focusPressed = false;
            m_gyro.m_canRotate = false;
        }
    }

    public void Jump()
    {
        jumpPressed = true;
    }
}
