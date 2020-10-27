using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text m_shotCounter;
    public int m_count = 0;

    public void DisplayUpdate()
    {
        m_shotCounter.text = "Shots Fired: " + m_count;
    }
}
