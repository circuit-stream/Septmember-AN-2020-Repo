using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public Transform m_target;
    public NavMeshAgent m_AI;
    // Update is called once per frame
    void Update()
    {
        m_AI.SetDestination(m_target.position);
    }
}
