using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerSecond : MonoBehaviour
{
    [SerializeField] GameObject[] obstacle;

    [SerializeField] int SpawnType;

    public float SpawnTime;

    public float SpawnAreaXplus;

    public float SpawnAreaXminus;
    //生成ポイントのx軸
    public float SpawnrandX;
    //生成ポイントのy軸
    public float SpawnrandY;
    //制限時間の再設定
    public float CurrentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime -= Time.deltaTime;

        if (SpawnTime <= 0)
        {
            //SpawnrandX = Random.Range(SpawnAreaXminus, SpawnAreaXplus);

            SpawnType = Random.Range(0, 2);

            Instantiate(obstacle[SpawnType], new Vector3(SpawnrandX, SpawnrandY, 0.0f), Quaternion.identity);

            SpawnTime = CurrentTime;
        }

    }
}
