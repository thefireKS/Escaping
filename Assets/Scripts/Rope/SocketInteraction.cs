using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketInteraction : MonoBehaviour
{
    private GameObject hook = null;
    private GameObject wire = null;

    public static Action SocketIsPlugged;
    private void Awake()
    {
        wire = GameObject.FindGameObjectWithTag("Wire");
        hook = GameObject.FindGameObjectWithTag("Hook");
    }
    public void Plug()
    {
        if (!wire.GetComponent<TakeRope>().isHoldingRope) return;
        hook.gameObject.transform.SetParent(transform);
        hook.gameObject.transform.localPosition = Vector3.zero;
        SocketIsPlugged?.Invoke();
    }
}
