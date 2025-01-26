using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyObstacle : MonoBehaviour
{
    public float DestroyTime;

    [SerializeField] Vector2 vector;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float CloudMoveX;

    [SerializeField] float CloudMoveY;

    [SerializeField] float CloudSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2 (CloudMoveX, -CloudMoveY);
    }

    // Update is called once per frame
    void Update()
    {
        //vector = new Vector2(
        //    -CloudMoveX, -CloudMoveY
        //    ).normalized * CloudSpeed;
        //rb.velocity = vector;


        Destroy(gameObject, DestroyTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ゲームオーバー");

            FindFirstObjectByType<PlayerController>().CharacterDead();
        }
    }
}