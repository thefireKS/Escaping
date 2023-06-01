using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractions : MonoBehaviour
{
    [SerializeField] private BoxCollider2D cardCollider;
    private void OnEnable() => Tumbler.disableCamera += DisableCamera;

    private void OnDisable() => Tumbler.disableCamera -= DisableCamera;
    
    [SerializeField]private BoxCollider2D visionZone;

    private void Start()
    {
        visionZone = GetComponentInChildren<BoxCollider2D>();
    }

    private void DisableCamera()
    {
        visionZone.gameObject.SetActive(false);
        cardCollider.enabled = true;
    }
    
}
