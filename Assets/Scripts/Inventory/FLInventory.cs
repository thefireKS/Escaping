using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject flashLight;

    private void OnEnable() => FLInteraction.flashlightInInventory += ActivateInventorySlot;
    
    private void OnDisable() => FLInteraction.flashlightInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        inventoryButton.SetActive(true);
    }

    public void TakeFlashLightInHands()
    {
        flashLight.SetActive(!flashLight.activeSelf);
    }
}
