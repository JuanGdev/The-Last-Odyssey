using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineFreeLook cinemachineFreeLook;
    // Start is called before the first frame update
    void Start()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            EnableCameraControl();
        else DisableCameraControl();
    }

    void EnableCameraControl()
    {
        cinemachineFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
        cinemachineFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
    }

    void DisableCameraControl()
    {
        cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
        cinemachineFreeLook.m_YAxis.m_InputAxisName = "";

        cinemachineFreeLook.m_XAxis.m_InputAxisValue = 0f;
        cinemachineFreeLook.m_YAxis.m_InputAxisValue = 0f;
    }
}
