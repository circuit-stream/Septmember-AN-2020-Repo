using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimShoot : MonoBehaviour
{
    public GameObject m_prefabFireball;
    public Transform m_spawn;
    public float m_shootForce;

    public ShotCounter m_scScript;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject tempFireBall = Instantiate(m_prefabFireball, m_spawn.position, m_spawn.rotation);
            tempFireBall.GetComponent<Rigidbody>().AddForce(m_spawn.forward * m_shootForce);
            Destroy(tempFireBall, 5);
            m_scScript.m_count++;
            m_scScript.DisplayUpdate();
        }
    }
}
