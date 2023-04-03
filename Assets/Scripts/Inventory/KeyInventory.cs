using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject key;

    private void OnEnable() => KeyInteraction.keyInInventory += ActivateInventorySlot;
    
    private void OnDisable() => KeyInteraction.keyInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        inventoryButton.SetActive(true);
    }

    public void TakeKeyInHands()
    {
        key.SetActive(!key.activeSelf);
    }
}
