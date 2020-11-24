using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    public string m_horizontalAxisName;
    public string m_verticalAxisName;

    public Transform m_director;
    public Transform m_vrPlayer;
    public float m_moveSpeed;

    private Vector3 m_playerForward;
    private Vector3 m_playerRight;

    // Update is called once per frame
    void Update()
    {
        Vector2 joystick;

        joystick.x = Input.GetAxis(m_horizontalAxisName);
        joystick.y = Input.GetAxis(m_verticalAxisName);

        //Dead Zone
        if(joystick.magnitude < 0.25)
        {
            return;
        }
        //=========

        m_playerForward = m_director.forward;
        m_playerRight = m_director.right;
        m_playerForward.y = 0;
        m_playerRight.y = 0;
        m_playerForward.Normalize();
        m_playerRight.Normalize();

        m_playerForward = m_playerForward * joystick.y * Time.deltaTime * -m_moveSpeed;
        m_playerRight = m_playerRight * joystick.x * Time.deltaTime * m_moveSpeed;

        m_vrPlayer.position += m_playerForward + m_playerRight;
    }
}
