using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player")) return;
        animator.SetBool("Detected",true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("Detected",false);
    }
}
