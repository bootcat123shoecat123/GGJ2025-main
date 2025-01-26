using SupSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallItemController : MonoBehaviour
{
    // Start is called before the first frame update
    ItemType type;
    [SerializeField] List<Sprite> sprite;
    void Start()
    {
        type=(ItemType)Enum.ToObject(typeof(ItemType), UnityEngine.Random.Range(0, Enum.GetNames(typeof(ItemType)).Length));
        GetComponent<SpriteRenderer>().sprite = sprite[(int)type];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindFirstObjectByType<SoundController>().PlayAudio("GaugeHeal", SoundController.AudioType.SE);

            switch (type)
            {
                case ItemType.Speed:

                    //collision.GetComponent<PlayerController>().CharacterHeal(3);
                    collision.GetComponent<PlayerController>().MoveSpeed = 3f;
                    break;
                case ItemType.Heath:
                    collision.GetComponent<PlayerController>().CharacterHeal(15);
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
public enum ItemType
{
    Speed,
    Heath
}