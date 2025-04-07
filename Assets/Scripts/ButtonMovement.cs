using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ButtonMovement : MonoBehaviour
{
    Rigidbody m_rigidbody;

    bool leftPressed, rightPressed;
    public float m_speed;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (leftPressed && !rightPressed)
        {
            m_rigidbody.velocity = new Vector3(-1 * m_speed, 0, 0);
        }
        else if (rightPressed && !leftPressed)
        {
            m_rigidbody.velocity = new Vector3(1 * m_speed, 0, 0);
        }
        else
        {
            m_rigidbody.velocity = Vector3.zero;
        }
    }

    public void MoveLeft()
    {
        Debug.Log("Left");

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
        Debug.Log("Right");


        if (!rightPressed)
        {
            rightPressed = true;
        }            
        else
        {
            rightPressed = false;
        }
    }
}
