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
    //�����|�C���g��x��
    public float SpawnrandX;
    //�����|�C���g��y��
    public float SpawnrandY;
    //�������Ԃ̍Đݒ�
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
