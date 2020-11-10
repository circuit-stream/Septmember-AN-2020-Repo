using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Haptics : MonoBehaviour
{
    public XRNode m_node;
    private InputDevice m_vrController;
    private bool m_canVibrate;

    private void Awake()
    {
        m_vrController = InputDevices.GetDeviceAtXRNode(m_node);

        if (m_vrController.isValid)
        {
            HapticCapabilities hapCap = new HapticCapabilities();
            m_vrController.TryGetHapticCapabilities(out hapCap);

            if (hapCap.supportsImpulse)
            {
                m_canVibrate = true;
            }
        }
    }

    public void Vibrate(float strength, float duration)
    {
        if(m_canVibrate)
        {
            m_vrController.SendHapticImpulse(0, strength, duration);
        }
    }
}
