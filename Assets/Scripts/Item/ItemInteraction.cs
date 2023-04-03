using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private Transform room;
    [Space(5)]
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
        
        if (room.localScale.x < 0)
        {
            notifyIcon.transform.localScale = new Vector3(-1, 1, 1);
        }
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
