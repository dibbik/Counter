using UnityEngine;

public class CounterView : MonoBehaviour
{
    public void ShowCount(int count)
    {
        Debug.Log("�������: " + count);
    }

    public void ShowMessage(string message)
    {
        Debug.Log(message);
    }
}