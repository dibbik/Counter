using System;
using UnityEngine;

public class InputReader : MonoBehaviour 
{
    const int LeftMouseButton = 0;

    public event Action OnToggleRequested;

    public void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnToggleRequested?.Invoke();
        }
    }
}