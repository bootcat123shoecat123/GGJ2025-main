using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public UnityEngine.GameObject[] Enemy;

    public int EnemyType;

    public float SpawnTime;

    public float SpawnAreaXplus;

    public float SpawnAreaXminus;

    public float SpawnrandX;

    public float SpawnrandY;


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
            SpawnrandX = Random.Range(SpawnAreaXminus, SpawnAreaXplus);

            EnemyType = Random.Range(0, 2);

            Instantiate(Enemy[EnemyType], new Vector3(SpawnrandX, SpawnrandY, 0.0f), Quaternion.identity);

            SpawnTime = CurrentTime;
        }
    }
}
