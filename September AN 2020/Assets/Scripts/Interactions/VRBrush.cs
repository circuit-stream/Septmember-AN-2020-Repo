using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBrush : MonoBehaviour
{
    public GameObject m_prefabTrail;
    public Transform m_spawnPoint;

    private GameObject m_currentTrail;

    
    void Interact()
    {
        m_currentTrail = Instantiate(m_prefabTrail, m_spawnPoint.position, m_spawnPoint.rotation, m_spawnPoint);
    }

    void Release()
    {
        m_currentTrail.transform.SetParent(null);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paint")
        {
            m_prefabTrail.GetComponent<TrailRenderer>().material = collision.collider.GetComponent<Renderer>().material;
        }
    }
}
