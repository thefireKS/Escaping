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

    public void Detected()
    {
        animator.SetBool("Detected",true);
    }

    public void unDetected()
    {
        animator.SetBool("Detected",false);
    }
}
