using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerStay(Collider other)
    {
        triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}