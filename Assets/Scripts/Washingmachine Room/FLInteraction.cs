using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLInteraction : MonoBehaviour
{
    public static Action flashlightInInventory;
    private void OnMouseDown()
    {
        flashlightInInventory?.Invoke();
        Destroy(gameObject);
    }
}
