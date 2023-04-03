using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSwapper : MonoBehaviour
{
    [SerializeField] private Transform[] rooms;
    private Vector3[] positions;

    private void Awake()
    {
        positions = new Vector3[rooms.Length];
        for (var i = 0; i < rooms.Length; i++)
            positions[i] = rooms[i].position;

        RoomPositionRandomizer();
    }

    private void RoomPositionRandomizer()
    {
        foreach (var room in rooms)
        {
            var posIndex = Random.Range(0, positions.Length);
            while (positions[posIndex] == Vector3.zero)
            {
                posIndex = Random.Range(0, positions.Length);
            }

            if (room.position.x > 0 && positions[posIndex].x < 0 || room.position.x < 0 && positions[posIndex].x > 0)
                room.localScale = new Vector3(-1 * room.localScale.x, room.localScale.y);
            
            room.position = positions[posIndex];
            positions[posIndex] = Vector3.zero;
        }
    }
}
