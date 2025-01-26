using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] UnityEngine.GameObject[] obstacle;

    public float SpawnTime;

    public float SpawnAreaXplus;

    public float SpawnAreaXminus;
    //�����|�C���g��x��
    public float SpawnrandX;
    //�����|�C���g��y��
    public float SpawnrandY;
    //�������Ԃ̍Đݒ�
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
