using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGun : MonoBehaviour
{
    public GameObject m_prefabBit;
    public float m_shootForce;
    public Transform m_spawnPoint;

    public GameObject m_prefabPS;
    void Interact()
    {
        GameObject go = Instantiate(m_prefabBit, m_spawnPoint.position, m_spawnPoint.rotation);
        go.GetComponent<Rigidbody>().AddForce(m_spawnPoint.forward * m_shootForce);

        StartCoroutine(SpawnParticleObject(go));
    }

    IEnumerator SpawnParticleObject(GameObject bit)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(m_prefabPS, bit.transform.position, Quaternion.identity);
        Destroy(bit);
    }
}
