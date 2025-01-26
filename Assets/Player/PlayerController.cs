using DG.Tweening;
using SupSystem;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //ˆÚ“®‚Ì‘¬‚³
    public float MoveSpeed=1f;
    private float SidePadding=7.5f;
    private float coolTime = 0.7f;
    public Rigidbody2D rd;
    bool IsMoving=false;
    bool IsTargeting=false;
    public GameObject bullet;
    public float HP=100f;
    float discountSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100f;
    }

    // Update is called once per frame
    void Update()
    {

        MoveCheck();
        if (IsMoving)
        {
            CharactorMove();
        }
        coolTime += Time.deltaTime;
        if (coolTime > 0.7f)
        {
            TargetCheck();
        }
        CharacterHealthDiscount();
    }
    void TargetCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IsTargeting = true;
            GetComponent<Animator>().SetBool("IsTargeting", IsTargeting);
        }
        if (Input.GetMouseButtonUp(1))
        {
            IsTargeting = false;
            GetComponent<Animator>().SetBool("IsTargeting", IsTargeting);
            Fire();
        }
    }
    void Fire()
    {
        


            FindFirstObjectByType<SoundController>().PlayAudio("PlayerShot", SoundController.AudioType.SE);
        Quaternion rotation = Quaternion.Euler(0, 0, GetAim(gameObject.transform.position, (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0)) / 100));
        //Quaternion shotRotate= Quaternion.FromToRotation(gameObject.transform.position, vector);
        Debug.Log(rotation.eulerAngles);
        Instantiate(bullet,transform.position, rotation);
        coolTime = 0;
    }
    float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
    void MoveCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsMoving = true;
            GetComponent<Animator>().SetBool("IsMove", IsMoving);
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsMoving = false;
            GetComponent<Animator>().SetBool("IsMove", IsMoving);
            rd.velocity = Vector3.zero;
        }
    }
    void CharactorMove()
    {
        float moveVector = (Input.mousePosition.x - (Screen.width / 2)) / 100 - gameObject.transform.position.x;
        
        if ((gameObject.transform.position.x > SidePadding) && (moveVector > 0))
        {
            rd.velocity = Vector2.zero;
            return;
        }
        if ((gameObject.transform.position.x < -SidePadding) && (moveVector < 0))
        {
            rd.velocity = Vector2.zero;
            return;
        }
        
        rd.velocity = new Vector2(moveVector, 0) * MoveSpeed;
    }
    void CharacterHealthDiscount()
    {
        HP-=Time.deltaTime*discountSpeed;
        
        if (HP < 0) {
            CharacterDead();
        }
        else
        {
            
            GameObject.Find("HPSlider").GetComponent<UnityEngine.UI.Slider>().value= HP / 100;
        }

    }
    
    void AppendRank()
    {
        Instantiate(Resources.Load("Prefab/Ranking"), Vector3.up * Screen.height, new Quaternion());
    }
    void PlayerFail()
    {
        transform.DOJump(transform.position + Vector3.down * 5, 2f, 1, 1f);
    }
    public void CharacterDead()
    {

        if (!GetComponent<Animator>().GetBool("IsDead")) {
            FindFirstObjectByType<SoundController>().PlayAudio("PlayerHit", SoundController.AudioType.SE);
            GetComponent<Animator>().SetBool("IsDead", true);
        Invoke(nameof(AppendRank), 1);
        Invoke(nameof(PlayerFail), 0.4f);
        }
    }
    public void CharacterHeal(float hpUp)
    {
        float newHP=Math.Clamp(HP + hpUp, 0, 100);
        DOTween.To(() => HP, x => HP = x, newHP, 1f);
        
    }
}
