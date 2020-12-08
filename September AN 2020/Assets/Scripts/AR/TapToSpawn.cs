using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToSpawn : MonoBehaviour
{
    public GameObject m_prefabObject;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    public ARRaycastManager m_aRRaycastManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if(m_aRRaycastManager.Raycast(touch.position, s_hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_hits[0].pose;
                    Instantiate(m_prefabObject, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
