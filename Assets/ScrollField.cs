using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollField : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] Vector3 StartPosition;

    [SerializeField] private float ResetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�O�i�̃X�N���[��
        transform.position -= new Vector3(0, Time.deltaTime * speed, 0);

        //�����ʒu�ɖ߂�
        if (transform.position.y <= ResetPosition)
        {
            transform.position = StartPosition;
        }
    }
}
