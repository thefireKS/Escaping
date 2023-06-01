using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject key;
    [SerializeField] private Sprite Alternate;
    [SerializeField] private Sprite Base;
    [SerializeField] private UnityEngine.UI.Image Where;

    private void OnEnable() => KeyInteraction.keyInInventory += ActivateInventorySlot;
    
    private void OnDisable() => KeyInteraction.keyInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        inventoryButton.SetActive(true);
    }

    public void TakeKeyInHands()
    {
        key.SetActive(!key.activeSelf);
        Where.sprite = key.activeSelf ? Alternate : Base;
    }
}
