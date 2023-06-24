using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    public float minDelay = 5f; // 최소 대기 시간
    public float maxDelay = 10f; // 최대 대기 시간

    private Coroutine activationCoroutine;
    private GameObject previousObject;

    private Animator animator;

    private Transform playerTransform; // 플레이어의 위치

    private float bossPositionX;
    private float playerPositionX;
    // Start is called before the first frame update
    void Start()
    {  
        animator = GetComponent<Animator>();

        // 모든 오브젝트를 비활성화합니다.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        // 랜덤한 시간 간격으로 오브젝트 활성화 코루틴을 시작합니다.
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
        // 랜덤한 대기 시간을 계산합니다.
        float randomDelay = Random.Range(minDelay, maxDelay);

        // 이전에 실행 중인 코루틴이 있다면 중지합니다.
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        // 지정된 대기 시간 후에 오브젝트 활성화 코루틴을 시작합니다.
        activationCoroutine = StartCoroutine(ActivateRandomObjectAfterDelay(10.0f));
    }

    private IEnumerator ActivateRandomObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 랜덤한 확률로 오브젝트를 선택하여 활성화합니다.
        GameObject selectedObject = GetRandomObjectWithProbability();
        if (selectedObject != null)
        {
            selectedObject.SetActive(true);

            animator.SetBool("Pattern", true);

            StartCoroutine(SetBoolAfterDelay(2f));

            // 이전 오브젝트가 있다면 비활성화합니다.
            if (previousObject != null)
            {
                previousObject.SetActive(false);
            }

            // 현재 오브젝트를 이전 오브젝트로 설정합니다.
            previousObject = selectedObject;
           
        }

        // 다음 오브젝트가 활성화될 때 이전 오브젝트를 비활성화하도록 코루틴을 재시작합니다.
        StartActivationCoroutine();
    }

    private GameObject GetRandomObjectWithProbability()
    {
        // 오브젝트 활성화 확률을 계산합니다.
        float[] probabilities = new float[objectsToActivate.Length];
        float totalProbability = 0f;
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            probabilities[i] = Random.value;
            totalProbability += probabilities[i];
        }

        // 확률에 따라 오브젝트를 선택합니다.
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

        // delay 후에 값을 false로 변경
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