using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float speed;
    private Rigidbody2D _playerRb;
    private Animator _animator;
    private LadderSystem _ladder;

    private Vector2 _move;
    private float _climb, climbingTimer = 0;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    public static Action GoingUp;
    public static Action GoingDown;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        transform.position = spawnPosition.position;
    }

    private void Update()
    {
        _move = new Vector2(Input.GetAxis("Horizontal"), 0);
        _climb = Input.GetAxis("Vertical");
        climbingTimer += Time.deltaTime;
        Laddering();
        PlayerMovement();
        RightFacing();
    }
    
    private void PlayerMovement()
    {
        Vector2 moveVector = transform.TransformDirection(_move) * speed; //make freeze rotation
        var velocity = _playerRb.velocity;
        velocity = new Vector2(moveVector.x, velocity.y);
        _playerRb.velocity = velocity;
        _animator.SetBool(IsRunning, velocity.x != 0);
    }
    
    private void RightFacing()
    { 
        if (Input.GetAxisRaw("Horizontal") > 0) 
            transform.localScale = new Vector3(2, 2, 2);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            transform.localScale = new Vector3(-2, 2, 2);
    }

    private void Laddering()
    {
        if(climbingTimer < 0.5f) return;
        switch (_climb)
        {
            case > 0:
                GoingUp?.Invoke();
                break;
            case < 0:
                GoingDown?.Invoke();
                break;
        }
        climbingTimer = 0f;
    }
}
