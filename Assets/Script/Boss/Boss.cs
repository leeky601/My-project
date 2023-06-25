using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Ȱ��ȭ�� ������Ʈ �迭
    public GameObject Tornado;

    private Coroutine activationCoroutine;
    private GameObject previousObject;
    public Slider healthSlider;

    public GameObject LeftKick;
    public GameObject RightKick;
    
    private Animator animator;

    private Transform playerTransform; // �÷��̾��� ��ġ

    private float bossPositionX;
    private float playerPositionX;
    private int maxHp;
    private int hp;

    

    //private bool paze = false;

    public AudioClip soundClip;
    public AudioClip soundClip2;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100;
        hp = maxHp;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // ��� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        // ������ �ð� �������� ������Ʈ Ȱ��ȭ �ڷ�ƾ�� �����մϴ�.
        StartActivationCoroutine();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        healthSlider.value = (float)hp / maxHp;
        playerPositionX = playerTransform.position.x;
        bossPositionX = transform.position.x;
        if (hp >= 50)
        {
            if (audioSource.clip != soundClip)
            { audioSource.clip = soundClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        if (hp < 50)
        {
            //paze = true;
            animator.SetBool("change", true);
            StartCoroutine(SetBoolAfterDelaychange(2f));
            Tornado.SetActive(true);
            if (audioSource.clip != soundClip2)
            { audioSource.clip = soundClip2;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        if (hp <= 0)
        {
            SceneManager.LoadScene(7);
        }

       
       
    }

    private void StartActivationCoroutine()
    {
        // ������ ��� �ð��� ����մϴ�.
        

        // ������ ���� ���� �ڷ�ƾ�� �ִٸ� �����մϴ�.
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        // ������ ��� �ð� �Ŀ� ������Ʈ Ȱ��ȭ �ڷ�ƾ�� �����մϴ�.
        activationCoroutine = StartCoroutine(ActivateRandomObjectAfterDelay(10.0f));
    }

    private IEnumerator ActivateRandomObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ������ Ȯ���� ������Ʈ�� �����Ͽ� Ȱ��ȭ�մϴ�.
        GameObject selectedObject = GetRandomObjectWithProbability();
        if (selectedObject != null)
        {
            selectedObject.SetActive(true);
            
            animator.SetBool("Pattern", true);
            StartCoroutine(SetBoolAfterDelay(2f));
                    
            // ���� ������Ʈ�� �ִٸ� ��Ȱ��ȭ�մϴ�.
            if (previousObject != null)
            {
                previousObject.SetActive(false);
            }

            // ���� ������Ʈ�� ���� ������Ʈ�� �����մϴ�.
            previousObject = selectedObject;
           
        }

        // ���� ������Ʈ�� Ȱ��ȭ�� �� ���� ������Ʈ�� ��Ȱ��ȭ�ϵ��� �ڷ�ƾ�� ������մϴ�.
        StartActivationCoroutine();
    }

    private GameObject GetRandomObjectWithProbability()
    {
        // ������Ʈ Ȱ��ȭ Ȯ���� ����մϴ�.
        float[] probabilities = new float[objectsToActivate.Length];
        float totalProbability = 0f;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            probabilities[i] = Random.value;
            totalProbability += probabilities[i];
        }

        // Ȯ���� ���� ������Ʈ�� �����մϴ�.
        float randomValue = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return objectsToActivate[i];
            }
        }

        return null;
    }
    IEnumerator SetBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // delay �Ŀ� ���� false�� ����
        animator.SetBool("Pattern", false);
    }

    IEnumerator SetBoolAfterDelayLkick(float delay)
    {
        yield return new WaitForSeconds(delay);

       
        
        animator.SetBool("leftkick", false);
    }

    IEnumerator SetBoolAfterDelayRkick(float delay)
    {
        yield return new WaitForSeconds(delay);

      
        animator.SetBool("rightkick", false);
    }

    IEnumerator SetBoolAfterDelaychange(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("change", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerPositionX <= bossPositionX && other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("leftkick", true);
            StartCoroutine(SetBoolAfterDelayLkick(1f));
        }

        if (playerPositionX > bossPositionX && other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("rightkick", true);
            StartCoroutine(SetBoolAfterDelayRkick(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_P"))
        {
            hp -= 1;
            Debug.Log(hp);
        }
    }

    public void SetActiveLKick()
    {
        LeftKick.SetActive(true);
    }

    public void SetActiveLKickFalse()
    {
        LeftKick.SetActive(false);
    }

    public void SetActiveRKick()
    {
       RightKick.SetActive(true);
    }

    public void SetActiveRKickFalse()
    {
        RightKick.SetActive(false);
    }

}