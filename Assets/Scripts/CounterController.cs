using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private float _countInterval = 0.5f;

    private Counter _counter;
    private CounterView _counterView;
    private CounterInputHandler _inputHandler;
    private Coroutine _countingCoroutine;
    private bool _isRunning;

    private void Awake()
    {
        InitializeComponents();
        SetupSubscriptions();
    }

    private void InitializeComponents()
    {
        _counter = new Counter(_countInterval);
        _counterView = new CounterView();
        _inputHandler = new CounterInputHandler();
    }

    private void SetupSubscriptions()
    {
        _counter.OnCountChanged += _counterView.ShowCount;
        _inputHandler.OnToggleRequested += ToggleCounter;
    }

    private void Update()
    {
        _inputHandler.Update();
    }

    private void OnDestroy()
    {
        CleanupSubscriptions();
        StopAllCounting();
    }

    private void CleanupSubscriptions()
    {
        if (_counter != null)
            _counter.OnCountChanged -= _counterView.ShowCount;

        if (_inputHandler != null)
            _inputHandler.OnToggleRequested -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        _isRunning = !_isRunning;

        if (_isRunning)
        {
            StartCounting();
            _counterView.ShowMessage("—четчик запущен");
        }
        else
        {
            StopCounting();
            _counterView.ShowMessage("—четчик остановлен");
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
            _counter.StopCounting();
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private void StopAllCounting()
    {
        if (_counter != null)
            _counter.StopCounting();

        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }
}