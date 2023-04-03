using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private GameObject notifyIcon;
    [SerializeField] private Sprite highlitedSprite;

    private Sprite _defaultSprite;
    private bool isActive;
    
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private ItemTriggerZone _itemTriggerZone;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _itemTriggerZone = GetComponentInChildren<ItemTriggerZone>();

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
        Destroy(_itemTriggerZone);
        ChangeActivity();
        _animator.SetBool("IsBroken",true);
        Destroy(this);
    }
}
