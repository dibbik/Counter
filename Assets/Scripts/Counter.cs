using System;
using System.Collections;
using UnityEngine;

public class Counter
{
    public event Action<int> CountChanged;

    private int _count;

    private readonly float _interval;

    private WaitForSeconds _waitForSeconds;

    private bool _isCounting;

    public Counter(float interval = 0.5f)
    {
        _interval = interval;
        _waitForSeconds = new WaitForSeconds(_interval);
    }

    public IEnumerator CountCoroutine()
    {
        _isCounting = true;

        while (_isCounting)
        {
            yield return _waitForSeconds;
            _count++;
            CountChanged?.Invoke(_count);
        }
    }

    public void ToggleCounting()
    {
        _isCounting = !_isCounting;
    }

    public bool IsCounting()
    {
        return _isCounting;
    }

    public int GetCurrentCount()
    {
        return _count;
    }

}