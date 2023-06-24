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

    // Start is called before the first frame update
    void Start()
    {
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
        activationCoroutine = StartCoroutine(ActivateRandomObjectAfterDelay(randomDelay));
    }

    private IEnumerator ActivateRandomObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // ������ Ȯ���� ������Ʈ�� �����Ͽ� Ȱ��ȭ�մϴ�.
        GameObject selectedObject = GetRandomObjectWithProbability();
        if (selectedObject != null)
        {
            selectedObject.SetActive(true);

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

}