using System;
using System.Collections;
using UnityEngine;

public class Counter 
{
    public event Action<int> OnCountChanged;

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
            Increment();
        }
    }

    private void Increment()
    {
        _count++;
        OnCountChanged?.Invoke(_count);
    }

    public void StopCounting()
    {
        _isCounting = false;
    }

    public int GetCurrentCount()
    {
        return _count;
    }

    public void Reset()
    {
        _count = 0;
        OnCountChanged?.Invoke(_count);
    }
}