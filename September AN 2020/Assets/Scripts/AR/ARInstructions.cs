using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructions : MonoBehaviour
{
    public List<GameObject> m_steps = new List<GameObject>();
    public GameObject m_mainMenu;

    int m_currentStep; //index of the list

    public void NextStep()
    {
        if(m_currentStep < m_steps.Count - 1) //if not on last step of list
        {
            m_steps[m_currentStep].SetActive(false); //turn off the current step
            m_currentStep++; //Increase current Step value
            m_steps[m_currentStep].SetActive(true); //turn on the next step
        }
        else //if on the last step
        {
            m_steps[m_currentStep].SetActive(false); //Turn off the last step
            m_currentStep = 0; //Reset the current step value back to 0
            m_steps[m_currentStep].SetActive(true); //Turn back on the first step

            m_mainMenu.SetActive(true); //Turn the main menu back on
            this.gameObject.SetActive(false); //Turn off this set of instructions
        }
    }
}
