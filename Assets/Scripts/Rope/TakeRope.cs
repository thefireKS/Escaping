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

    public bool isHoldingRope = false;
    

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
        if (isHoldingRope)
            GiveRopeInHands();
        else
            SetRopeOnDefaultPlace();
    }
    public void Taking()
    {
        isHoldingRope = !isHoldingRope;
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
}
