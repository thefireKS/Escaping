using System;
using UnityEngine;

public class CardInteraction : MonoBehaviour
{
    public static Action cardInInventory;

    private void OnEnable() => Tumbler.disableCamera += ChangePickable;

    private void OnDisable() => Tumbler.disableCamera -= ChangePickable;

    private bool canPickUp = false;
    private void ChangePickable()
    {
        canPickUp = !canPickUp;
    }
    private void OnMouseDown()
    {
        if (!canPickUp) return;
        cardInInventory?.Invoke();
        Destroy(gameObject);
    }
}
