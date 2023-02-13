using Cinemachine;
using UnityEngine;

public class ScalerWithWheel : MonoBehaviour
{
    [SerializeField] private float minScale, maxScale;

    private CinemachineVirtualCamera _cinemachine;
    [SerializeField] private CinemachineVirtualCamera fullScreenCinemachine;
    private float _currentScale, wheelInput;

    private Vector3 zeroPosition = new Vector3(0,0,-10);
    private void Start()
    {
        _cinemachine = GetComponent<CinemachineVirtualCamera>();
        _currentScale = minScale;
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
        _cinemachine.m_Lens.OrthographicSize = _currentScale;
        fullScreenCinemachine.m_Lens.OrthographicSize = _currentScale;
    }

    private void CameraPositioning()
    {
        if (_currentScale > 0.75 * maxScale)
        {
            fullScreenCinemachine.Priority = 20;
            _cinemachine.Priority = 10;
            fullScreenCinemachine.transform.position = zeroPosition;
        }
        else
        {
            _cinemachine.Priority = 20;
            fullScreenCinemachine.Priority = 10;
        }
    }
}