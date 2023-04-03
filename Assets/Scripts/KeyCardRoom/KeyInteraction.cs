using System;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public static Action keyInInventory;
    private void OnMouseDown()
    {
        keyInInventory?.Invoke();
        Destroy(gameObject);
    }
}
