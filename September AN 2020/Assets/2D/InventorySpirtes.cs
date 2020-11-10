using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpirtes : MonoBehaviour
{
    public Texture m_current;

    public void Store(Texture t)
    {
        m_current = t;
    }

    public void Set(Image i)
    {
        i.material.mainTexture = m_current;
    }
}
