using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGrab : MonoBehaviour
{
    public Animator m_anim;

    private GameObject m_collidingObject;
    private GameObject m_heldObject;

    //Hand position tracking List
    public List<Vector3> m_handPositions = new List<Vector3>();
    public float m_throwingForce = 3000f;
    //public Transform m_vrRig; //For VR
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", true);
            if(m_collidingObject)
            {
                //Grab();
                PhysicsGrab();
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_anim.SetBool("isGrabbing", false);
            if(m_heldObject)
            {
                //Release();
                ThrowObject();
            }
        }

        if (m_heldObject)
        {
            m_handPositions.Add(transform.position);
            if (m_handPositions.Count > 4)
            {
                m_handPositions.RemoveAt(0);
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
        fx.breakForce = 5000;
        fx.breakTorque = 5000;
        m_heldObject.transform.SetParent(transform);
    }

    private void OnJointBreak(float breakForce)
    {
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

        //dir = Quaternion.Euler(0, m_vrRig.eulerAngles.y, 0) * dir; //For VR
        rb.AddForce(dir * m_throwingForce);

    }
}
