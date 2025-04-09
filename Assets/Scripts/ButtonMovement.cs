using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ButtonMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody m_rigidbody;

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
            m_rigidbody.velocity = new Vector3(-1 * m_speed, -2, 0); //TODO: Watch out when adding jumping, need to counteract this downwards force too
        }
        else if (rightPressed && !leftPressed)
        {
            m_rigidbody.velocity = new Vector3(1 * m_speed, -2, 0);
        }
        else
        {
            m_rigidbody.velocity = new Vector3(0, -2, 0);
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
}
