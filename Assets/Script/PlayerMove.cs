using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speedBoostAmount = 5.0f; // �̵� �ӵ� ������
    public float duration = 3.0f; // ������ ���� �ð�
    private float originalSpeed;
    public float speed = 3.0f;
    private Animator animator;
    private Rigidbody2D rb;         // Rigidbody2D ������Ʈ
    private Vector2 moveDirection;  // �̵� ���� ����

    private Camera mainCamera;
    private Vector3 mousePosition;
    private LifeText lifetext;

    public float invincibleTime = 0.5f; // ���� �ð�
    private bool invincible = false; // ���� ���� ����
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
        // Rigidbody2D ������Ʈ�� velocity �Ӽ��� �̿��� �̵�
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
        // ���� �̵� �ӵ� ����
        originalSpeed = speed;

        // �̵� �ӵ� ����
        speed += speedBoostAmount;

        // ������ ���� �ð� �Ŀ� �̵� �ӵ��� ���� ������ �ǵ���
        StartCoroutine(ResetSpeedAfterDuration());
      
    }

    private System.Collections.IEnumerator ResetSpeedAfterDuration()
    {
        // ���� �ð� ���� ���
        yield return new WaitForSeconds(duration);

        // �̵� �ӵ� ���� ������ �ǵ���
        speed = originalSpeed;

        // ������ ȿ�� ����
        EndSpeedBoost();
    }

    private void EndSpeedBoost()
    {

    }

  
}

