using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SupSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject RestartButton;
    public GameObject TitleButton;

    // Start is called before the first frame update
    void Start()
    {
        RestartButton.SetActive(false);
        TitleButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                Restart();
            }
            else
            {
                FindFirstObjectByType<SoundController>().PlayAudio("Pause", SoundController.AudioType.SE);
                
                Stop();

                RestartButton.SetActive(true);
                TitleButton.SetActive(true);
            }
        }
    }

    public void Stop()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;

        RestartButton.SetActive(false);
        TitleButton.SetActive(false);
    }

    public void Title()
    {
        FindFirstObjectByType<SoundController>().PlayAudio("Botton", SoundController.AudioType.SE);
        SceneManager.LoadScene("Title");
    }
}
