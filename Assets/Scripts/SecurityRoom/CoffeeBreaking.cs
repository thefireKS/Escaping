using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBreaking : MonoBehaviour
{
    [SerializeField] private GameObject CoffeeBreakingMiniGame;

    private void OnTriggerStay2D(Collider2D col)
    {
        if(!col.CompareTag("Player"))return;
        if(!Input.GetKey(KeyCode.E)) return;
        
        CoffeeBreakingMiniGame.SetActive(true);
    }
}
