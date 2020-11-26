using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRRig : MonoBehaviour
{
    public Transform m_vrHead;
    public CapsuleCollider m_body;

    private void Awake()
    {
        XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);

        //if(Application.platform == RuntimePlatform.Android)
        //{
        //    OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.Medium;
        //}
    }


    // Update is called once per frame
    void Update()
    {
        m_body.center = new Vector3(m_vrHead.localPosition.x, m_body.center.y, m_vrHead.localPosition.z);
    }
}
