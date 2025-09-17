using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private float _countInterval = 0.5f;

    private Counter _counter;
    private Coroutine _countingCoroutine;

    private void Awake()
    {
        _counter = new Counter(_countInterval);
        _counter.CountChanged += DisplayCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        _counter.ToggleCounting();

        if (_counter.IsCounting())
        {
            StartCounting();
            Debug.Log("—четчик запущен");
        }
        else
        {
            StopCounting();
            Debug.Log("—четчик остановлен");
        }
    }

    private void StartCounting()
    {
        if (_countingCoroutine == null)
        {
            _countingCoroutine = StartCoroutine(_counter.CountCoroutine());
        }
    }

    private void StopCounting()
    {
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private void DisplayCount(int count)
    {
        Debug.Log($"—четчик: {count}");
    }

    private void OnDestroy()
    {
        if (_counter != null)
            _counter.CountChanged -= DisplayCount;
    }
}