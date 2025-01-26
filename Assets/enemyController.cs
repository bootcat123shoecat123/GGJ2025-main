using SupSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class enemyController : MonoBehaviour
{
    UnityEngine.GameObject player;

    [SerializeField] Rigidbody2D rb;

    public float speed;

    public float StopDistance;

    public Animator animator;

    bool Moving;

    bool Dead;

    bool One;

    public float UpCount;

    TimerText timerText;

    Transform Playertr;
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindFirstObjectByType<PlayerController>().gameObject;

        Playertr = player.GetComponent<Transform>();

        Moving = true;

        timerText= FindObjectOfType<TimerText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == true)
        {
            if (Vector2.Distance(transform.position, Playertr.position) < StopDistance)
                return;

            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(Playertr.position.x, Playertr.position.y),
                speed * Time.deltaTime);
        }

        if (Moving == false)
        {
            UpCount--;

            if (UpCount > 0)
            {
            }
            if (UpCount < 0)
            {
                float delta = Time.deltaTime;
                animator.SetTrigger("Defeat");

                transform.Translate(0, delta, 0);
            }
        }

        if (Dead == true)
        {
            Dead = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&Moving==true)
        {
            Debug.Log("ゲームオーバー");

            FindFirstObjectByType<SoundController>().PlayAudio("BubbleBreak", SoundController.AudioType.SE);
            FindFirstObjectByType<PlayerController>().CharacterDead();
        }

        if (collision.gameObject.tag == "Bullet" && Moving)
        {
            //Instantiate(Resources.Load("Prefab/FallItem"), transform.position, new Quaternion());

            Debug.Log("あたりました");
            animator.SetBool("Beat",true);
            Moving = false;
        }

        if(Moving == false)
        {
            if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
            {
                if (One == false)
                {

                    Invoke(nameof(Instance), 0f);
                    Dead = true;
                    One = true;
                }
                FindFirstObjectByType<SoundController>().PlayAudio("EnemyHit", SoundController.AudioType.SE);
                timerText.Score += 100;
                Debug.Log(timerText.Score);
                //rb.gravityScale = 0.3f;

                Destroy(gameObject);
            }
        }

        //if (Moving == false)
        //{
        //    if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Player")
        //    {
        //        timerText.Score += 100;
        //        Debug.Log(timerText.Score);
        //        Destroy(gameObject);
        //    }
        //}

        if (collision.gameObject.tag == "Destroy")
        {
            Debug.Log("消えました");
            Destroy(gameObject);
        }
    }
    void Instance()
    {
        Instantiate(Resources.Load("Prefab/FallItem"), transform.position, new Quaternion());
    }
}
