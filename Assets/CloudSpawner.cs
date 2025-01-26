using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject obstacle;

    public float SpawnTime;

    public float SpawnAreaXLeftplus;

    public float SpawnAreaXLeftminus;

    public float SpawnAreaXlightplus;

    public float SpawnAreaXlightminus;

    public float LeftOrRight;

    //生成ポイントのx軸
    public float SpawnrandX;
    //生成ポイントのy軸
    public float SpawnrandY;
    //制限時間の再設定
    public float CurrentTime;

    public Vector3 spawnPosition;
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
            LeftOrRight = Random.Range(1, 3);

            if (LeftOrRight == 1) 
            {
                SpawnrandX = Random.Range(SpawnAreaXlightplus, SpawnAreaXlightminus);

            }else if(LeftOrRight == 2)
            {
                SpawnrandX = Random.Range(SpawnAreaXLeftplus, SpawnAreaXLeftminus);
            }

            Instantiate(obstacle, new Vector3(SpawnrandX, SpawnrandY, 0.0f), Quaternion.identity);

            spawnPosition= new Vector3(SpawnrandX, SpawnrandY, 0.0f);

            SpawnTime = CurrentTime;
        }
    }
}
