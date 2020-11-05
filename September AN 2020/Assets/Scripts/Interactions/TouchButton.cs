using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : MonoBehaviour
{
    public Transform m_buttonMesh;
    public Transform m_down;

    public UnityEvent m_buttonPressed;
    public UnityEvent m_buttonReleased;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_buttonMesh.position = m_down.position;
            m_buttonPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            m_buttonMesh.position = transform.position;
            m_buttonReleased.Invoke();
        }
    }
}
