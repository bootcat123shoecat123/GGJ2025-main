using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class ScoreState 
{
    
    private static ScoreState instance = null;

    public List<float> ranking;
    /// <summary>
    /// Instanceの糖衣構文
    /// </summary>
    public static ScoreState I => Instance;
    public static ScoreState Instance
    {
        get
        {
            CreateInstance();
            return instance;
        }
    }
    /// <summary>
    /// Instance 生成
    /// </summary>
    public static void CreateInstance()
    {
        if (instance == null)
        {
            
            instance = new ScoreState();
        }
    }

    /// <summary>
    /// Instanceが存在するかどうか
    /// </summary>
    /// <returns></returns>
    public static bool IsExists()
    {
        return instance != null;
    }
    // Start is called before the first frame update
    public void AddRank(float record)
    {
        if (ranking == null) ranking = new List<float>();
        
        ranking.Add(record);
        ranking.Sort();
        ranking.Reverse();
    }
}

public struct Record
{
    public float score;
}
