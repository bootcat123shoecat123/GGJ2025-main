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
        StartCoroutine(CountdownRoutine()); // カウントダウンを開始
    }

    IEnumerator CountdownRoutine()
    {
        while (countDown > 0)
        {
            CountText.text = countDown.ToString(); 
            yield return new WaitForSecondsRealtime(MinusTime); 
            countDown--;
        }

        CountText.text = "Go"; // 最後に "Go" を表示
        yield return new WaitForSecondsRealtime(MinusTime); // 1秒間 "Go" を表示
        CountText.gameObject.SetActive(false); // テキストを非表示（または Destroy()）

        Time.timeScale = 1.0f; // ゲームを再開
    }
}
