using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 4f;
    
    public float range = 5f;
    public float attackDelay = 1f;
    public GameObject projectilePrefab;
   

    public float pushForce = 0.5f;
    public float pushForce2 = 0.1f;
    public float pushDuration = 0.5f;
    public float pushDuration2 = 0.2f;
    public bool isPushing = false;

    public Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    public int hp = 2;

    private float attackTimer = 0.5f;

    public GameObject itemDropPrefab;

    Vector2 direction;

    public AudioClip monsterDieClip;
    public AudioClip monsterATKClip;
    private AudioSource audioSource;
    // Start is called before the first frame update

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
        
     
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("checkDie") == false)
        {
            LookAt();

            // Move towards player

            direction = player.position - transform.position;
            // Check if in attack range
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= range)
            {

                if (attackTimer <= 0)
                {
                    audioSource.PlayOneShot(monsterATKClip);
                    // Shoot projectile
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 500f);
                    attackTimer = attackDelay;
                }
                else
                {
                    attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                Move();
            }
        }
    }

    void Move()
    {
        if (isPushing == false)
        {
            Vector2 direction = player.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);

        }
    }

    void LookAt()
    {
        direction = player.position - transform.position;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_P"))
        {
            hp -= 1;
            if (hp == 0)
            {
                Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
                animator.SetBool("checkDie", true);
                audioSource.clip = monsterDieClip;
                audioSource.Play();
                Destroy(gameObject, 0.15f);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어와 충돌 시
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position; //충돌 방향 계산
                StartCoroutine(AddForceCoroutine(rb, pushDirection.normalized));  //밀어냄
            }
        }
        else if (collision.gameObject.CompareTag("Enemy")) //적과 충돌 시
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position;//충돌 방향 계산
                StartCoroutine(AddForceCoroutine2(rb, pushDirection.normalized)); //밀어냄
            }
        }
    }
    IEnumerator AddForceCoroutine(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // 자신을 밀어냅니다.
        yield return new WaitForSeconds(pushDuration); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; // 자신의 속도 초기화
        isPushing = false;
    }

    IEnumerator AddForceCoroutine2(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce2, ForceMode2D.Impulse); // 자신을 밀어냅니다.
        yield return new WaitForSeconds(pushDuration2); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; // 자신의 속도 초기화
        isPushing = false;
    }

}
