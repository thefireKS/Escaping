using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private GameObject notifyIcon;
    [SerializeField] private Sprite highlitedSprite;
    private SpriteRenderer _spriteRenderer;
    private Sprite _defaultSprite;
    private bool isActive;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
    }
    public void ChangeActivity()
    {
        isActive = !isActive;
        _spriteRenderer.sprite = isActive ? highlitedSprite : _defaultSprite;
        notifyIcon.SetActive(isActive);
    }
    private void OnMouseDown ()
    {
        Destroy(gameObject);
    }
}
