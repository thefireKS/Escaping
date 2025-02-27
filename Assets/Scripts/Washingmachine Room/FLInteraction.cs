using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLInteraction : MonoBehaviour
{
    public static Action flashlightInInventory;
    [SerializeField] private Vector3 New;

    private void OnEnable() => SocketInteraction.SocketIsPlugged += ChangePickable;

    private void OnDisable() => SocketInteraction.SocketIsPlugged -= ChangePickable;
    private bool canPickUp = false;
    private void ChangePickable()
    {
        canPickUp = true;
        transform.position = transform.parent.transform.position + New;
    }
    private void OnMouseDown()
    {
        if (!canPickUp) return;
        flashlightInInventory?.Invoke();
        Destroy(gameObject);
    }
}
