using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using SupSystem;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject settingScene;
    // Start is called before the first frame update
    private void Start()
    {
        FindFirstObjectByType<SoundController>()?.PlayAudio(FindFirstObjectByType<SoundController>()?.BGM[0],SoundController.AudioType.BGM,true);
    }

    public void LoadScene()
    {

        FindFirstObjectByType<SoundController>().PlayAudio("Botton", SoundController.AudioType.SE);
        this.GetComponent<CanvasGroup>().DOFade(0, 3f);
        Invoke( nameof(GoScene),3f);
    }
    public void Setting()
    {

        FindFirstObjectByType<SoundController>().PlayAudio("Botton", SoundController.AudioType.SE);
        Instantiate(settingScene, FindFirstObjectByType<Canvas>().transform);
    }
    public void Quit()
    {

        FindFirstObjectByType<SoundController>().PlayAudio("Botton", SoundController.AudioType.SE);
        Application.Quit();
    }
    void GoScene()
    {

        SceneManager.LoadScene("GameMain");
        
    }
}
