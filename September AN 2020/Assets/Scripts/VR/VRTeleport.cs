using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    public Transform m_vrRig;
    public Transform m_vrCamera;
    public string m_teleportButton;

    private LineRenderer m_myLine;
    private RaycastHit m_hit;
    private bool m_canTeleport;
    private Vector3 m_difference;
    // Start is called before the first frame update
    void Start()
    {
        m_myLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(m_teleportButton))
        {
            if(Physics.Raycast(transform.position, transform.forward, out m_hit, 100))
            {
                m_myLine.enabled = true;
                m_myLine.SetPosition(0, transform.position);
                m_myLine.SetPosition(1, m_hit.point);
                m_canTeleport = true;
            }
            else
            {
                m_canTeleport = false;
                m_myLine.enabled = false;
            }
        }
        else if(Input.GetButtonUp(m_teleportButton))
        {
            m_myLine.enabled = false;
            if(m_canTeleport)
            {
                m_canTeleport = false;

                m_difference = m_vrRig.position - m_vrCamera.localPosition;
                m_difference.y = 0;

                m_vrRig.position = m_hit.point + m_difference;
            }
        }
    }
}
