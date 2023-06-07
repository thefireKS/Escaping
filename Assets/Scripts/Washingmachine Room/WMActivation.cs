using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMActivation : MonoBehaviour
{
    private Interaction _animator;

    private void Start()
    {
        _animator = GetComponent<Interaction>();
    }

    private void OnEnable() => SocketInteraction.SocketIsPlugged += MachineIsEnabled;

    private void OnDisable() => SocketInteraction.SocketIsPlugged -= MachineIsEnabled;
    
    private void MachineIsEnabled()
    {
        _animator.StateActivation("IsWorking");
    }
}
