using System;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public static Action keyInInventory;
    public void PickUp()
    {
        keyInInventory?.Invoke();
        Destroy(gameObject);
    }
}
