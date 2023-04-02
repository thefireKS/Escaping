using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketInteraction : MonoBehaviour
{
    private bool isInsideInteractionZone = false;
    private GameObject player = null;

    public static Action SocketIsPlugged;
    private void Update()
    {
        if(!isInsideInteractionZone) return;

        if (!Input.GetKey(KeyCode.E)) return;
        
        var hook = player.transform.Find("Hook");
        
        if(hook == null) return;
        hook.gameObject.transform.SetParent(transform);
        hook.gameObject.transform.localPosition = Vector3.zero;
        SocketIsPlugged?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        isInsideInteractionZone = true;
        player = col.gameObject;
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        isInsideInteractionZone = false;
        player = null;
    }
}
