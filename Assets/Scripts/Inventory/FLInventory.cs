using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject flashLight;
    [SerializeField] private Sprite Alternate;
    [SerializeField] private Sprite Base;
    [SerializeField] private UnityEngine.UI.Image Where;
    private void OnEnable() => FLInteraction.flashlightInInventory += ActivateInventorySlot;
    
    private void OnDisable() => FLInteraction.flashlightInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        inventoryButton.SetActive(true);
    }
    
    public void TakeFlashLightInHands()
    {
        flashLight.SetActive(!flashLight.activeSelf);
        Where.sprite = flashLight.activeSelf ? Alternate : Base;
    }
}
