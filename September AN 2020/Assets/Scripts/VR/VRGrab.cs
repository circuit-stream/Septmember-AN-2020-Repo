using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public string m_gripAxisName;
    private bool m_gripHeld;

    public Animator m_anim;

    private GameObject m_collidingObject;
    private GameObject m_heldObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            m_collidingObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_collidingObject = null;
    }

    void Update()
    {
        if (Input.GetAxis(m_gripAxisName) > 0.8f && m_gripHeld == false)
        {
            m_gripHeld = true;
            m_anim.SetBool("isGrabbing", true);
            if(m_collidingObject)
            {
                Grab();
            }
        }
        else if (Input.GetAxis(m_gripAxisName) < 0.8f && m_gripHeld == true)
        {
            m_gripHeld = false;
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                Release();
            }
        }
    }

    void Grab()
    {
        m_heldObject = m_collidingObject;
        m_heldObject.GetComponent<Rigidbody>().isKinematic = true;
        m_heldObject.transform.SetParent(transform);
    }

    void Release()
    {
        m_heldObject.transform.SetParent(null);
        m_heldObject.GetComponent<Rigidbody>().isKinematic = false;
        m_heldObject = null;
    }
}

