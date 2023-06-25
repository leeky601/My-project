using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3f;

    public float pushForce = 0.5f;
    public float pushForce2 = 0.1f;
    public float pushDuration = 0.5f;
    public float pushDuration2 = 0.2f;
    public bool isPushing = false;


    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;

    public int hp = 3;

    public GameObject itemDropPrefab;

    public AudioClip monsterDieClip; 
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

     
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("checkDie") == false)
        {
            Move();
            LookAt();
        }
    }



    void Move()
    {
        if (isPushing == false) //플레이어와 충돌 확인
        {
            Vector2 direction = player.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            //플레이어에게 다가감

        }
   }

    void LookAt() //애니메이션
    {
        Vector2 direction = player.position - transform.position;
        direction.y = 0;

        if (direction.x > 0)
        {
            animator.SetBool("moveLeft", false);
        }
        else
        {
            animator.SetBool("moveLeft", true);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어와 충돌 시
        {
            isPushing = true; 
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position; //플레이어 충돌 방향 구함.
                StartCoroutine(AddForceCoroutine(rb, pushDirection.normalized)); //충돌 시 밀어냄
            }
        }
        else if (collision.gameObject.CompareTag("Enemy")) //적과 충돌 시
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position; //적끼리 충돌 방향 구함
                StartCoroutine(AddForceCoroutine2(rb, pushDirection.normalized)); //충돌 시 밀어냄
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_P")) //플레이어 총알과 충돌 시
        {
            hp -= 1;
            if (hp == 0) //죽으면
            {
                Instantiate(itemDropPrefab, transform.position, Quaternion.identity); //아이템 드랍
                animator.SetBool("checkDie", true);
                audioSource.clip = monsterDieClip; //죽는 소리
                audioSource.Play();
                Destroy(gameObject,0.15f);
            }
        }

    }
    IEnumerator AddForceCoroutine(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // 자신을 밀어냄
        yield return new WaitForSeconds(pushDuration); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; //자신의 속도 초기화
        isPushing = false;
    }

    IEnumerator AddForceCoroutine2(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce2, ForceMode2D.Impulse); // 자신을 밀어냄
        yield return new WaitForSeconds(pushDuration2); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; //자신의 속도 초기화
        isPushing = false;
    }
}
