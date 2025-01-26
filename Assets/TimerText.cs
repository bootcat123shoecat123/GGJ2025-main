using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public float Timer;

    public float Score;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        //timerText = GetComponent();
        Score = 0;
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 0.3f)
        {
            Timer = 0;
            Score += 1;
        }

        timerText.text="Score"+Score.ToString("0");
    }
}
