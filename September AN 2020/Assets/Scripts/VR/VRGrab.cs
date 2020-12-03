using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public string m_gripAxisName;
    private bool m_gripHeld;

    public string m_triggerAxisName;
    private bool m_triggerHeld;

    public Animator m_anim;

    public Haptics m_hScript;

    private GameObject m_collidingObject;
    private GameObject m_heldObject;


    private List<Vector3> m_handPositions = new List<Vector3>();
    public float m_throwingForce = 4000f;
    //public Transform m_vrRig;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vibrate")
        {
            m_hScript.Vibrate(0.5f, 0.1f);
        }
    }


    void Update()
    {
        if (Input.GetAxis(m_gripAxisName) > 0.8f && m_gripHeld == false)
        {
            m_gripHeld = true;
            m_anim.SetBool("isGrabbing", true);
            if(m_collidingObject)
            {
                //Grab();
                PhysicsGrab();
            }
        }
        else if (Input.GetAxis(m_gripAxisName) < 0.8f && m_gripHeld == true)
        {
            m_gripHeld = false;
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                //Release();
                m_heldObject.SendMessage("Release");
                ThrowObject();
            }
        }

        if(m_heldObject)
        {
            m_handPositions.Add(transform.position);
            if(m_handPositions.Count > 4)
            {
                m_handPositions.RemoveAt(0);
            }
        }

        if(Input.GetAxis(m_triggerAxisName) > 0.8f && !m_triggerHeld)
        {
            m_triggerHeld = true;
            if(m_heldObject)
            {
                m_heldObject.SendMessage("Interact");
            }
        }
        if(Input.GetAxis(m_triggerAxisName) < 0.8f && m_triggerHeld)
        {
            m_triggerHeld = false;
            if(m_heldObject)
            {
                m_heldObject.SendMessage("Release");
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

    void PhysicsGrab()
    {
        m_heldObject = m_collidingObject;
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = m_heldObject.GetComponent<Rigidbody>();
        fx.breakForce = 5000f;
        fx.breakTorque = 5000f;
        m_heldObject.transform.SetParent(transform);
    }

    private void OnJointBreak(float breakForce)
    {
        m_heldObject.SendMessage("Release");
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;
    }

    void ThrowObject()
    {
        Vector3 dir;
        Rigidbody rb = m_heldObject.GetComponent<Rigidbody>();
        Destroy(GetComponent<FixedJoint>());
        m_heldObject.transform.SetParent(null);
        m_heldObject = null;

        try
        {
            dir = m_handPositions[3] - m_handPositions[0];
        }
        catch
        {
            dir = Vector3.zero;
        }

        rb.AddForce(dir * m_throwingForce);
    }
}

