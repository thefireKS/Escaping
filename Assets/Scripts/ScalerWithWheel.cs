using Cinemachine;
using UnityEngine;

public class ScalerWithWheel : MonoBehaviour
{
    [SerializeField] private float minScale, maxScale;
    [SerializeField] private Transform followingObject, defaultFollowingObject;
    
    private Camera _camera;
    private CinemachineVirtualCamera _cinemachine;
    private float _currentScale, wheelInput;

    private Vector3 defaultPosition = new Vector3(0, 0, -10);
    private Vector3 _currentPosition;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _cinemachine = GetComponent<CinemachineVirtualCamera>();
        _currentScale = minScale;
        _currentPosition = _cinemachine.Follow.gameObject.transform.position;
    }

    private void Update()
    {
        WheelInput();
        if (wheelInput == 0) return;
        CameraZooming();
        CameraPositioning();
    }
    
    private void WheelInput()
    {
        wheelInput = -Input.GetAxis("Mouse ScrollWheel");
        _currentScale += wheelInput;
        if (_currentScale > maxScale) _currentScale = maxScale;
        if (_currentScale < minScale) _currentScale = minScale;
    }
    private void CameraZooming()
    {
        _camera.orthographicSize = _currentScale;
    }

    private void CameraPositioning()
    {
        _cinemachine.Follow = _currentScale > maxScale * 0.66 ? defaultFollowingObject : followingObject;
        transform.position = Vector3.Lerp(_currentPosition,defaultPosition,_currentScale/maxScale);
    }
}