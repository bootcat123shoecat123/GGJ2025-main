using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject[] obstacle;

    public float SpawnTime;

    public float SpawnAreaXplus;

    public float SpawnAreaXminus;
    //生成ポイントのx軸
    public float SpawnrandX;
    //生成ポイントのy軸
    public float SpawnrandY;
    //制限時間の再設定
    public float CurrentTime;

    public int ObjectNumber;

    public int ObjectCountMax;

    public int ObjectCountMin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime -=Time.deltaTime;

        if(SpawnTime <= 0)
        {
           SpawnrandX =Random.Range(SpawnAreaXminus, SpawnAreaXplus);

            ObjectNumber= Random.Range(ObjectCountMax, ObjectCountMin);

            Instantiate(obstacle[ObjectNumber],new Vector3(SpawnrandX, SpawnrandY, 0.0f),Quaternion.identity);

            SpawnTime = CurrentTime;
        }
        
    }
}
