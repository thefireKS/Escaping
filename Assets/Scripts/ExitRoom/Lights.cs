using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() => Tumbler.enableLights += TurnLightsOn;

    private void OnDisable() => Tumbler.enableLights -= TurnLightsOn;
    private void TurnLightsOn()
    {
        spriteRenderer.enabled = false;
    }
}
