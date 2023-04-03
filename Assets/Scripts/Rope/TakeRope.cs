using System;
using UnityEngine;

public class TakeRope : MonoBehaviour
{
    [SerializeField] private Transform room;
    [Space(5)]
    [Header("Transform controls of the wire")]
    [Space(5)]
    [SerializeField] private Transform defaultRopePosition;
    [SerializeField] private Transform rightWall;
    [SerializeField] private Transform leftWall;

    private bool isInsideInteractionZone = false;
    private bool isHoldingRope = false;
    

    private Transform player;
    private Transform takeRopePosition;
    
    private Rope rope;

    private void Start()
    {
        rope = GetComponent<Rope>();
        player = GameObject.FindWithTag("Player").transform;
        takeRopePosition = GameObject.Find("Hands").transform;
        
        if (room.localScale.x < 0)
        {
            (rightWall, leftWall) = (leftWall, rightWall);
        }
    }

    private void OnEnable()
    {
        SocketInteraction.SocketIsPlugged += PlugIn;
        SecurityPatrol.dropHook += SetRopeOnDefaultPlace;
    }

    private void OnDisable()
    {
        SocketInteraction.SocketIsPlugged -= PlugIn;
        SecurityPatrol.dropHook -= SetRopeOnDefaultPlace;
    }

    private void Update()
    {
        RopePositionSetter();
        
        if(!isInsideInteractionZone) return;

        if (Input.GetKeyDown(KeyCode.E))
            isHoldingRope = !isHoldingRope;

        if (isHoldingRope)
            GiveRopeInHands();
        else
            SetRopeOnDefaultPlace();
    }

    private void PlugIn()
    {
        Destroy(this);
    }

    private void SetRopeOnDefaultPlace()
    {
        rope.hook.gameObject.transform.SetParent(rope.transform);
        rope.hook.gameObject.transform.localPosition = defaultRopePosition.localPosition;
        isHoldingRope = false;
    }

    private void GiveRopeInHands()
    {
        rope.hook.gameObject.transform.SetParent(player);
        rope.hook.gameObject.transform.localPosition = takeRopePosition.localPosition;
    }

    private void RopePositionSetter()
    {
        var hookX = rope.hook.gameObject.transform.position.x;
        
        
        if(hookX > rightWall.position.x || hookX < leftWall.position.x)
            SetRopeOnDefaultPlace();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;
        isInsideInteractionZone = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInsideInteractionZone = false;
    }
}
