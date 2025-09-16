using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterView _view;

    private int _count = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;

    void Start()
    {
        _view = GetComponent<CounterView>();

        if (_view == null)
        {
            Debug.LogError("CounterView не найден на этом же объекте");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            if (_countingCoroutine == null)
            {
                _countingCoroutine = StartCoroutine(CountUp());
            }

            _view?.ShowMessage("—четчик запущен!");
        }
        else
        {
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);
                _countingCoroutine = null;
            }
            _view?.ShowMessage("—четчик остановлен на значении: " + _count);
        }
    }

    private IEnumerator CountUp()
    {
        while (_isCounting)
        {
            _count++;
            _view?.ShowCount(_count);
            yield return new WaitForSeconds(0.5f);
        }
    }
}