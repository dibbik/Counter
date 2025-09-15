using UnityEngine;
using System.Collections;

public class Counter : MonoBehaviour
{
    private int count = 0;

    private bool isCounting = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCounting = !isCounting;

            if (isCounting)
            {
                StartCoroutine(CountUp());
                Debug.Log("—четчик запущен!");
            }
            else
            {
                Debug.Log("—четчик остановлен на значении: " + count);
            }
        }
    }

    IEnumerator CountUp()
    {
        while (isCounting)
        {
            Debug.Log("—четчик: " + count);

            count++;

            yield return new WaitForSeconds(0.5f);
        }
    }
}