using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(1.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 finalMovement = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
        GetComponent<Rigidbody2D>().AddForce(finalMovement);
        
        if ((transform.position.y<-5)||(transform.position.y>5))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Destroy")
        {
            Destroy(gameObject);
        }
    }
}
