using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] Vector2 vector;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float CloudMoveX;

    [SerializeField] float CloudMoveY;

    [SerializeField] float CloudSpeed;

    [SerializeField] bool Left;

    [SerializeField] CloudSpawner spawner;

    [SerializeField] GameObject cloudSpawner;

    [SerializeField] int LeftOrRightPosition;

    [SerializeField] float DestroyCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spawner = GameObject.Find("CloudSpawner").GetComponent<CloudSpawner>();


        if(spawner.spawnPosition.x<LeftOrRightPosition)
        {
            Left = true;
        }
        else
        {
            Left = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Left)
        {
            vector = new Vector2(
                CloudMoveX, -CloudMoveY
                ).normalized * CloudSpeed;
        }else if(!Left)
        {
            vector = new Vector2(
                -CloudMoveX, -CloudMoveY
            ).normalized * CloudSpeed;
        }

        rb.velocity = vector;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Destroy")
        {

            Destroy(gameObject/*, DestroyCount*/);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {

            Destroy(gameObject/*, DestroyCount*/);
        }
    }
    void OnBecameInvisible()
    {
    }
}
