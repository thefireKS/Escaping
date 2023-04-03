using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public static Action disableCamera;
    public static Action enableLights;

    [SerializeField] private bool shouldDisableCamera;
    [SerializeField] private bool shouldEnableLights;
    [SerializeField] private Transform button;

    private float buttonYPos;

    private void Start()
    {
        buttonYPos = button.transform.localPosition.y;
    }

    private void OnMouseDown()
    {
        button.localPosition = new Vector3(0, buttonYPos * -1);
        buttonYPos *= -1;
        if(shouldDisableCamera)
            disableCamera?.Invoke();
        if(shouldEnableLights)
            enableLights?.Invoke();
    }
}
