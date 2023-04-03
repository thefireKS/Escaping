using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPatrol : MonoBehaviour
{
    [SerializeField] private Transform room;
    [Space(5)]
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;
    [Space(5)]
    [SerializeField] private Transform rightPatrolPoint;
    [SerializeField] private Transform leftPatrolPoint;
    [Space(5)] 
    [SerializeField] private Transform coffeeMachine;
    [Space(5)]
    [SerializeField] private float speed;
    [SerializeField] private Transform GFX;

    private float resultSpeed;

    private float rPos, lPos, rEdg, lEdg;
    private float rotateTimer = 0f;

    private float diff = 0f, prevDiff = 999f;

    private const float rotationTime = 0.3f;
    private float xPos;

    private bool isPatroling = true;
    private bool isFollowing;
    private bool isGoingBackToPatrol;
    private bool isRepairing;

    private Transform player;
    private Vector3 defaultPosition;

    private Rigidbody2D rb2d;

    public static Action dropHook;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        defaultPosition = transform.position;
        
        resultSpeed = speed;

        rPos = rightPatrolPoint.position.x;
        lPos = leftPatrolPoint.position.x;

        rEdg = rightEdge.position.x;
        lEdg = leftEdge.position.x;

        if (room.localScale.x < 0)
        {
            (rPos, lPos) = (lPos, rPos);
            (rEdg, lEdg) = (lEdg, rEdg);
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnEnable() => CoffeeCode.machineIsBroken += GoToRepair;
    
    private void OnDisable() => CoffeeCode.machineIsBroken -= GoToRepair;

    private void Update()
    {
        rotateTimer += Time.deltaTime;
        
        rb2d.velocity = new Vector2(resultSpeed, rb2d.velocity.y);
        
        xPos = transform.position.x;
        
        Repair();
        
        Patrol();
        
        Follow();
        
        BackToPatrol();
    }

    private void Patrol()
    {
        if(!isPatroling) return;

        if (xPos > lPos && xPos < rPos) return;
        Rotate();
    }

    private void Follow()
    {
        if(!isFollowing) return;

        var playerX = player.transform.position.x;
        
        if (xPos > rEdg || xPos < lEdg)
        {
            isGoingBackToPatrol = true;
            isFollowing = false;
        }

        if ((!(playerX > xPos) || !(resultSpeed < 0)) && (!(playerX < xPos) || !(resultSpeed > 0))) return;
        Rotate();
    }

    private void BackToPatrol()
    {
        if(!isGoingBackToPatrol) return;
        
        var xDef = defaultPosition.x;

        diff = Math.Abs(xPos - xDef);
        
        if(diff > prevDiff)
            Rotate();

        prevDiff = diff;

        if (diff > 0.1f) return;
        isPatroling = true;
        isFollowing = false;
        isGoingBackToPatrol = false;
    }

    private void GoToRepair()
    {
        isRepairing = true;
        isPatroling = false;
        isFollowing = false;
        isGoingBackToPatrol = false;
        Debug.Log("BAM");
    }

    private void Repair()
    {
        if(!isRepairing) return;

        Debug.Log("We were here");
        
        var xCof = coffeeMachine.transform.position.x;
        
        diff = Math.Abs(xPos - xCof);

        prevDiff = diff;

        if (diff <= 0.1f)
        {
            rb2d.velocity = Vector2.zero;
            Destroy(this);
        }

        if ((!(xCof > xPos) || !(resultSpeed < 0)) && (!(xCof < xPos) || !(resultSpeed > 0))) return;
        Rotate();
    }

    private void Rotate()
    {
        if(rotateTimer <= rotationTime) return;
        
        resultSpeed = -1 * resultSpeed;
        var gfx = GFX.transform;
        gfx.localScale = new Vector3(-1 * gfx.localScale.x, 1, 1);
        
        rotateTimer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(isRepairing) return;
        if (!col.CompareTag("Player")) return;

        player = col.transform;
        var hook = col.gameObject.transform.Find("Hook");
        
        if(hook==null) return;
        
        dropHook?.Invoke();
        
        isFollowing = true;
        isPatroling = false;
    }
}