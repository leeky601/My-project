using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCactus : MonoBehaviour
{
    public float speed = 4f;

    public float range = 5f;
    public float attackDelay = 1f;
    
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;


    public float pushForce = 0.5f;
    public float pushForce2 = 0.1f;
    public float pushDuration = 0.5f;
    public float pushDuration2 = 0.2f;
    public bool isPushing = false;

    public Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    public int hp = 4;

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
                    Vector2 directionOffset = Quaternion.Euler(0f, 0f, 30f) * direction.normalized;
                    Vector2 directionOffset2 = Quaternion.Euler(0f, 0f, -30f) * direction.normalized;
                    // Shoot projectile
                    direction = player.position - transform.position;
                    direction.y = 0;
                    if (direction.x > 0)
                    {
                        GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        projectile.GetComponent<Rigidbody2D>().AddForce(directionOffset.normalized * 500f);
                        GameObject projectile2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        projectile2.GetComponent<Rigidbody2D>().AddForce(directionOffset2.normalized * 500f);
                    }
                    else
                    {
                        GameObject projectile = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
                        projectile.GetComponent<Rigidbody2D>().AddForce(directionOffset.normalized * 500f);
                        GameObject projectile2 = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
                        projectile2.GetComponent<Rigidbody2D>().AddForce(directionOffset2.normalized * 500f);
                    }
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position;
                StartCoroutine(AddForceCoroutine(rb, pushDirection.normalized)); // 밀어내는 코루틴 시작
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            isPushing = true;
            if (pushDuration > 0f)
            {
                Vector2 pushDirection = transform.position - collision.gameObject.transform.position;
                StartCoroutine(AddForceCoroutine2(rb, pushDirection.normalized)); // 밀어내는 코루틴 시작
            }
        }
    }
    IEnumerator AddForceCoroutine(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse); // 적을 밀어냅니다.
        yield return new WaitForSeconds(pushDuration); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; // 적의 속도 초기화
        isPushing = false;
    }

    IEnumerator AddForceCoroutine2(Rigidbody2D enemyRb, Vector2 pushDirection)
    {
        isPushing = true;
        enemyRb.AddForce(pushDirection * pushForce2, ForceMode2D.Impulse); // 적을 밀어냅니다.
        yield return new WaitForSeconds(pushDuration2); // 일정 시간 대기
        enemyRb.velocity = Vector2.zero; // 적의 속도 초기화
        isPushing = false;
    }

}
