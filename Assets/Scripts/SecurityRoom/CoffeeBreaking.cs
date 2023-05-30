using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBreaking : MonoBehaviour
{
    [SerializeField] private Sprite highlightedSprite;
    [Space(5)]
    [SerializeField] private GameObject CoffeeBreakingMiniGame;

    private Sprite defaultSprite;
    private SpriteRenderer spriteRenderer;

    private bool isHighlited;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag("Player"))return;

        ChangeActivity();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(!col.CompareTag("Player"))return;

        ChangeActivity();
    }

    private void OnMouseDown()
    {
        if(spriteRenderer.sprite == defaultSprite) return;
        
        CoffeeBreakingMiniGame.SetActive(true);
    }

    private void ChangeActivity()
    {
        isHighlited = !isHighlited;
        spriteRenderer.sprite = isHighlited ? highlightedSprite : defaultSprite;
    }
}
