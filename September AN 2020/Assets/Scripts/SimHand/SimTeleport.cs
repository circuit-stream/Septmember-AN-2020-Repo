using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SimTeleport : MonoBehaviour
{
    private LineRenderer m_myLine;
    private RaycastHit m_hit;
    private bool m_canTeleport;

    // Start is called before the first frame update
    void Start()
    {
        m_myLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (Physics.Raycast(transform.position, transform.forward, out m_hit))
            {
                m_myLine.enabled = true;
                m_myLine.SetPosition(0, transform.position);
                m_myLine.SetPosition(1, m_hit.point);
                m_canTeleport = true;
            }
            else
            {
                m_myLine.enabled = false;
                m_canTeleport = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            m_myLine.enabled = false;
            if (m_canTeleport)
            {
                m_canTeleport = false;
                transform.position = m_hit.point;
            }
        }
    }
}
