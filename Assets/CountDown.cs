using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Text CountText;

    float countDown = 3f;
    int count = 0;
    float start_time;
    float MinusTime=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 0;
        StartCoroutine(CountdownRoutine()); // �J�E���g�_�E�����J�n
    }

    IEnumerator CountdownRoutine()
    {
        while (countDown > 0)
        {
            CountText.text = countDown.ToString(); 
            yield return new WaitForSecondsRealtime(MinusTime); 
            countDown--;
        }

        CountText.text = "Go"; // �Ō�� "Go" ��\��
        yield return new WaitForSecondsRealtime(MinusTime); // 1�b�� "Go" ��\��
        CountText.gameObject.SetActive(false); // �e�L�X�g���\���i�܂��� Destroy()�j

        Time.timeScale = 1.0f; // �Q�[�����ĊJ
    }
}
