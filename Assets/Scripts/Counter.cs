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
                Debug.Log("������� �������!");
            }
            else
            {
                Debug.Log("������� ���������� �� ��������: " + count);
            }
        }
    }

    IEnumerator CountUp()
    {
        while (isCounting)
        {
            Debug.Log("�������: " + count);

            count++;

            yield return new WaitForSeconds(0.5f);
        }
    }
}