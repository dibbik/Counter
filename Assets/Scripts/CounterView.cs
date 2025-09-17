using UnityEngine;

public class CounterView 
{
    public void ShowCount(int count)
    {
        Debug.Log("—четчик: " + count);
    }

    public void ShowMessage(string message)
    {
        Debug.Log(message);
    }
}