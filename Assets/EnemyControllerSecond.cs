using SupSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControllerSecond : MonoBehaviour
{
    [SerializeField] Vector2 vector;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float CloudMoveX;

    [SerializeField] float CloudMoveY;


    [SerializeField] int LeftOrRightPosition;

    [SerializeField] float DestroyCount;

    [SerializeField] GameObject bullet;

    [SerializeField] float spawnTime;

    [SerializeField] float CurrentTime;

    public float UpCount;

    public Animator animator;

    public Color startColor;

    public bool Moving;

    bool Dead;

    bool One;

    bool Stop;

    TimerText timerText;


    // Start is called before the first frame update
    void Start()
    {
        Moving = true;

        timerText = FindObjectOfType<TimerText>();

        Dead = false;

        One = false;

        Stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == true)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime < 0)
            {
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                spawnTime = CurrentTime;
            }
            vector = new Vector2(
                CloudMoveX, CloudMoveY
                ).normalized;


            rb.velocity = vector;
        }

        if(Dead == true) 
        {
            Dead = false;
        }

    }

    private void FixedUpdate()
    {
        if (Moving == false)
        {

            animator.SetTrigger("Defeat");

            float delta = Time.deltaTime;

            //transform.Translate(0, delta, 0);

            vector = new Vector2(
                CloudMoveX, -CloudMoveY
                ).normalized;


            rb.velocity = vector;

            //UpCount--;
            //if (UpCount < 0)
            //{

            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Destroy")
        {

            Destroy(gameObject/*, DestroyCount*/);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ゲームオーバー");

            FindFirstObjectByType<SoundController>().PlayAudio("BubbleBreak", SoundController.AudioType.SE);
            FindFirstObjectByType<PlayerController>().CharacterDead();
        }
        if (collision.gameObject.tag == "Bullet" && Moving)
        {
            animator.SetBool("Beat", true);

            FindFirstObjectByType<SoundController>().PlayAudio("EnemyHit", SoundController.AudioType.SE);
            Debug.Log("あたりました");
            Moving = false;
        }

        if (Moving == false)
        {
            if (collision.gameObject.tag != "Bullet"&& collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
            {
                if (One == false)
                {
                    Dead = true;
                    Invoke(nameof(Instance), 0f);

                    One = true;
                }
                timerText.Score += 100;

                animator.SetTrigger("Break");

                FindFirstObjectByType<SoundController>().PlayAudio("EnemyHit", SoundController.AudioType.SE);

                Debug.Log(timerText.Score);

                Stop = true;

                //rb.gravityScale = 0.3f;

                Destroy(gameObject,animator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
    void Instance()
    {
        Instantiate(Resources.Load("Prefab/FallItem"), transform.position, new Quaternion());
    }
}
