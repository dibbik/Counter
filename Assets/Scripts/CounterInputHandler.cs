using System;
using UnityEngine;

public class CounterInputHandler
{
    public event Action OnToggleRequested;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnToggleRequested?.Invoke();
        }
    }
}