using System;
using UnityEngine;

public class Tumbler : MonoBehaviour
{
    public static Action disableCamera;
    public static Action enableLights;

    [SerializeField] private bool shouldDisableCamera;
    [SerializeField] private bool shouldEnableLights;

    public void TryChanges()
    {
        if(shouldDisableCamera)
            disableCamera?.Invoke();
        if(shouldEnableLights)
            enableLights?.Invoke();
    }
    
}
