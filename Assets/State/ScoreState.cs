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
    /// Instance�����ṽʸ
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
    /// Instance ����
    /// </summary>
    public static void CreateInstance()
    {
        if (instance == null)
        {
            
            instance = new ScoreState();
        }
    }

    /// <summary>
    /// Instance��¸�ߤ��뤫�ɤ���
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
