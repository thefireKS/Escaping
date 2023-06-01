using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryButton;
    [SerializeField] private GameObject card;
    [SerializeField] private Sprite Alternate;
    [SerializeField] private Sprite Base;
    [SerializeField] private UnityEngine.UI.Image Where;

    private void OnEnable() => CardInteraction.cardInInventory += ActivateInventorySlot;
    
    private void OnDisable() => CardInteraction.cardInInventory -= ActivateInventorySlot;
    private void ActivateInventorySlot()
    {
        inventoryButton.SetActive(true);
    }

    public void TakeCardInHands()
    {
        card.SetActive(!card.activeSelf);
        Where.sprite = card.activeSelf ? Alternate : Base;
    }
}
