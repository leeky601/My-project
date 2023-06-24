using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Ȱ��ȭ�� ������Ʈ �迭
    public float minDelay = 5f; // �ּ� ��� �ð�
    public float maxDelay = 10f; // �ִ� ��� �ð�

    private Coroutine activationCoroutine;
    private GameObject previousObject;

    private Animator animator;

    private Transform playerTransform; // �÷��̾��� ��ġ

    private float bossPositionX;
    private float playerPositionX;
    // Start is called before the first frame update
    void Start()
    {  
        animator = GetComponent<Animator>();

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

        playerPositionX = playerTransform.position.x;
        bossPositionX = transform.position.x;
    }

    private void StartActivationCoroutine()
    {
        // ������ ��� �ð��� ����մϴ�.
        float randomDelay = Random.Range(minDelay, maxDelay);

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

}