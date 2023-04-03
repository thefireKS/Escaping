using System;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
    public static Action cardInInventory;
    private void OnMouseDown()
    {
        cardInInventory?.Invoke();
        Destroy(gameObject);
    }
}
