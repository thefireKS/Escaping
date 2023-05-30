using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public static Action disableCamera;
    public static Action enableLights;

    [SerializeField] private bool shouldDisableCamera;
    [SerializeField] private bool shouldEnableLights;

    private Animator _animator;
    private bool _isEnabled = false;

    private string _animName;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animName = "L" + transform.name[^1];
    }

    private void OnMouseDown()
    {
        _animator.Play(_isEnabled ? _animName + " R" : _animName);
        _isEnabled = !_isEnabled;
        if(shouldDisableCamera)
            disableCamera?.Invoke();
        if(shouldEnableLights)
            enableLights?.Invoke();
    }
}
