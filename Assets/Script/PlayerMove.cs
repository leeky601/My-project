using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedBoostAmount = 5.0f; // 이동 속도 증가량
    public float duration = 3.0f; // 아이템 지속 시간
    private float originalSpeed;
    public float speed = 3.0f;
    private Animator animator;
    private Rigidbody2D rb;         // Rigidbody2D 컴포넌트
    private Vector2 moveDirection;  // 이동 방향 벡터

    private Camera mainCamera;
    private Vector3 mousePosition;
    private LifeText lifetext;

    public float invincibleTime = 0.5f; // 무적 시간
    private bool invincible = false; // 무적 상태 여부
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody2D>();

        lifetext = GameObject.Find("LifeText").GetComponent<LifeText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("checkDie") == false)
        {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Move();
            Character();
        }


    }

    void FixedUpdate()
    {
        // Rigidbody2D 컴포넌트의 velocity 속성을 이용해 이동
        rb.velocity = moveDirection * speed;
    }

    void Character()
    {
        Vector3 look;
        look.x = mousePosition.x - transform.position.x;
        look.y = mousePosition.y - transform.position.y;
        look.z = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("FrontIdle", false);
            animator.SetBool("LeftIdle", false);
            animator.SetBool("RightIdle", false);
            animator.SetBool("BackIdle", false);

            if (look.x > 0 && look.y > 0)
            {
                if (look.x > look.y)
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", true);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);


                }

                else
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", true);
                }
            }

            if (look.x > 0 && look.y < 0)
            {
                if (look.x > Mathf.Abs(look.y))
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", true);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);
                }

                else
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", true);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);
                }
            }

            if (look.x < 0 && look.y < 0)
            {
                if (Mathf.Abs(look.x) > Mathf.Abs(look.y))
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", true);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);
                }

                else
                {
                    animator.SetBool("LeftFrontMove", true);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);
                }
            }

            if (look.x < 0 && look.y > 0)
            {
                if (Mathf.Abs(look.x) > Mathf.Abs(look.y))
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", true);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", false);
                    animator.SetBool("RightBackMove", false);
                }

                else
                {
                    animator.SetBool("LeftFrontMove", false);
                    animator.SetBool("RightFrontMove", false);
                    animator.SetBool("LeftMove", false);
                    animator.SetBool("RightMove", false);
                    animator.SetBool("LeftBackMove", true);
                    animator.SetBool("RightBackMove", false);
                }
            }
        }

        else
        {
            animator.SetBool("LeftFrontMove", false);
            animator.SetBool("RightFrontMove", false);
            animator.SetBool("LeftMove", false);
            animator.SetBool("RightMove", false);
            animator.SetBool("LeftBackMove", false);
            animator.SetBool("RightBackMove", false);

            if (look.x > 0 && look.y > 0)
            {
                if (look.x > look.y)
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", true);
                    animator.SetBool("BackIdle", false);


                }

                else
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", true);
                }
            }

            if (look.x > 0 && look.y < 0)
            {
                if (look.x > Mathf.Abs(look.y))
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", true);
                    animator.SetBool("BackIdle", false);
                }

                else
                {
                    animator.SetBool("FrontIdle", true);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", false);
                }
            }

            if (look.x < 0 && look.y < 0)
            {
                if (Mathf.Abs(look.x) > Mathf.Abs(look.y))
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", true);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", false);
                }

                else
                {
                    animator.SetBool("FrontIdle", true);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", false);
                }
            }

            if (look.x < 0 && look.y > 0)
            {
                if (Mathf.Abs(look.x) > Mathf.Abs(look.y))
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", true);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", false);
                }

                else
                {
                    animator.SetBool("FrontIdle", false);
                    animator.SetBool("LeftIdle", false);
                    animator.SetBool("RightIdle", false);
                    animator.SetBool("BackIdle", true);
                }
            }

        }
    }
    void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        /* if (Input.GetKey(KeyCode.A))
         {

             transform.Translate(Vector3.left * speed * Time.deltaTime);
         }

         if (Input.GetKey(KeyCode.D))
         {

             transform.Translate(Vector3.right * speed * Time.deltaTime);
         }

         if (Input.GetKey(KeyCode.W))
         {

             transform.Translate(Vector3.up * speed * Time.deltaTime);
         }

         if (Input.GetKey(KeyCode.S))
         {

             transform.Translate(Vector3.down * speed * Time.deltaTime);
         }*/




    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible && other.CompareTag("Bullet_E"))
        {
            lifetext.Dead();
            invincible = true;
            Invoke("ResetInvincible", invincibleTime);
            if (lifetext.life == 0)
            {
                animator.SetBool("checkDie", true);
                Destroy(gameObject, 4f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!invincible && other.gameObject.CompareTag("Enemy"))
        {
            lifetext.Dead();
            invincible = true;
            Invoke("ResetInvincible", invincibleTime);
            if (lifetext.life == 0)
            {
                animator.SetBool("checkDie", true);
                Destroy(gameObject, 4f);
            }
        }
    }
    void ResetInvincible()
    {
        invincible = false;
    }

    public void StartSpeedBoost()
    {
        // 현재 이동 속도 저장
        originalSpeed = speed;

        // 이동 속도 증가
        speed += speedBoostAmount;

        // 아이템 지속 시간 후에 이동 속도를 원래 값으로 되돌림
        StartCoroutine(ResetSpeedAfterDuration());
      
    }

    private System.Collections.IEnumerator ResetSpeedAfterDuration()
    {
        // 일정 시간 동안 대기
        yield return new WaitForSeconds(duration);

        // 이동 속도 원래 값으로 되돌림
        speed = originalSpeed;

        // 아이템 효과 종료
        EndSpeedBoost();
    }

    private void EndSpeedBoost()
    {

    }

  
}

