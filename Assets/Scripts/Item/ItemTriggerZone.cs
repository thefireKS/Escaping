using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTriggerZone : MonoBehaviour
{
    private ItemInteraction itemInteraction;

    private void Start()
    {
        itemInteraction = GetComponentInParent<ItemInteraction>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            itemInteraction.ChangeActivity();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            itemInteraction.ChangeActivity();
    }
}
