using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLInteraction : MonoBehaviour
{
    public static Action flashlightInInventory;
    

    private void OnEnable() => SocketInteraction.SocketIsPlugged += ChangePickable;

    private void OnDisable() => SocketInteraction.SocketIsPlugged -= ChangePickable;
    private bool canPickUp = false;
    private void ChangePickable()
    {
        canPickUp = true;
    }
    private void OnMouseDown()
    {
        if (!canPickUp) return;
        flashlightInInventory?.Invoke();
        Destroy(gameObject);
    }
}
