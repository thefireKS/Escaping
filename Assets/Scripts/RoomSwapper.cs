using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSwapper : MonoBehaviour
{
    [SerializeField] private Transform[] rooms;
    private Vector3[] positions;

    private void Start()
    {
        positions = new Vector3[rooms.Length];
        for (var i = 0; i < rooms.Length; i++)
            positions[i] = rooms[i].position;
        
        foreach (var v3 in positions)
        {
            Debug.Log(v3);
        }
        
        RoomPositionRandomizer();
    }

    private void RoomPositionRandomizer()
    {
        foreach (var room in rooms)
        {
            var posIndex = Random.Range(0, positions.Length);
            while (rooms[posIndex].position == Vector3.zero)
            {
                posIndex = Random.Range(0, positions.Length);
            }
            
            room.position = positions[posIndex];
            positions[posIndex] = Vector3.zero;
        }
    }
}
