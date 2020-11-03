using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public string m_gripAxisName;
    private bool m_gripHeld;

    public Animator m_anim;

    void Update()
    {
        if (Input.GetAxis(m_gripAxisName) > 0.8f && m_gripHeld == false)
        {
            m_gripHeld = true;
            m_anim.SetBool("isGrabbing", true);
        }
        else if (Input.GetAxis(m_gripAxisName) < 0.8f && m_gripHeld == true)
        {
            m_gripHeld = false;
            m_anim.SetBool("isGrabbing", false);
        }
    }
}
