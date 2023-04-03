using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMActivation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable() => SocketInteraction.SocketIsPlugged += MachineIsEnabled;

    private void OnDisable() => SocketInteraction.SocketIsPlugged -= MachineIsEnabled;
    
    private void MachineIsEnabled()
    {
        _animator.SetBool("IsWorking",true);
    }
}
