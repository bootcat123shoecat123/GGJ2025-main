using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BulletControllerEnemy : MonoBehaviour
{
    public Rigidbody2D _rb;

    public float speed;

    // プレイヤーのTransformを参照するための変数
    public Transform player;
    Vector3 targetPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            targetPosition = playerObject.transform.position;
        }
    }
    private void Start()
    { 
        //transform.rotation = Quaternion.FromToRotation(transform.position, targetPosition);
        Vector2 finalMovement = targetPosition-transform.position;

       
        _rb.velocity = finalMovement * 1f;
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    GameObject playerObject = GameObject.FindWithTag("Player");

    //    if(playerObject != null )
    //    {
    //        targetPosition = playerObject.transform.position;
    //    }

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //transform.Translate(0,speed,0);

    //    //transform.Translate(Vector3.down * Time.deltaTime);

    //    //// プレイヤーへの方向ベクトルを計算
    //    //Vector3 direction = player.position - transform.position;

    //    //// ベクトルを正規化して移動方向を決定
    //    //direction.Normalize();

    //    //// オブジェクトを移動
    //    //transform.position += direction * speed * Time.deltaTime;


    //    transform.position = Vector2.MoveTowards(
    //        transform.position,
    //        new Vector2(targetPosition.x, targetPosition.y),
    //        speed * Time.deltaTime);

    //    if (transform.position.y < -5)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

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
