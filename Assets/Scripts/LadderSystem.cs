using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSystem : MonoBehaviour
{
    [SerializeField] private Transform UpperDoor, LowerDoor;

    private Transform _player;

    private void OnEnable()
    {
        Movement.GoingUp += GoUp;
        Movement.GoingDown += GoDown;
    }

    private void OnDisable()
    {
        Movement.GoingUp -= GoUp;
        Movement.GoingDown -= GoDown;
    }

    private void GoUp()
    {
        if(_player == null) return;
        if(UpperDoor == null) return;
        _player.position = UpperDoor.position;
    }

    private void GoDown()
    {
        if(_player == null) return;
        if(LowerDoor == null) return;
        _player.position = LowerDoor.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _player = col.transform;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _player = null;
    }
}
