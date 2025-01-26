using DG.Tweening;
using SupSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingAppend : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GridLayoutGroup grid;
    [SerializeField] GameObject rankText;
    [SerializeField] int rankLenth=3;
    void Start()
    {
        Time.timeScale = 0.0f; 
        transform.DOMove(Vector3.zero, 3f).SetUpdate(true);
        transform.Find("FinalScoreText").GetComponent<Text>().text= FindFirstObjectByType<TimerText>().Score.ToString();

        FindFirstObjectByType<SoundController>().PlayAudio("Result", SoundController.AudioType.SE);
        ScoreState.Instance.AddRank( FindFirstObjectByType<TimerText>().Score );
        int rank = 1;
        foreach (float item in ScoreState.Instance.ranking)
        {
            if (rank> rankLenth) break;
            GameObject newRankMember =Instantiate(rankText, grid.transform);
            newRankMember.GetComponent<Text>().text=rank.ToString()+"----"+item.ToString("0");
            rank++;

        }
    }

    public void PlayAgain()
    {

        FindFirstObjectByType<SoundController>().PlayAudio("Botton", SoundController.AudioType.SE);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    
}
