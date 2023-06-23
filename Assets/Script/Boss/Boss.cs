using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Ȱ��ȭ�� ������Ʈ �迭
    public float minTime = 10f; // �ּ� �ð� ����
    

    private Coroutine activationCoroutine;
    private List<GameObject> activatedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ��� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
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
        // ������ �ð� ������ ����մϴ�.
        

        // ������ ���� ���� �ڷ�ƾ�� �ִٸ� �����մϴ�.
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        // ������ �ð� ���� �Ŀ� ������Ʈ Ȱ��ȭ �ڷ�ƾ�� �����մϴ�.
        activationCoroutine = StartCoroutine(ActivateObjectAfterDelay(minTime));
    }

    private IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Ȱ��ȭ���� ���� ������Ʈ�� ���͸��մϴ�.
        List<GameObject> inactiveObjects = new List<GameObject>();
        foreach (GameObject obj in objectsToActivate)
        {
            if (!obj.activeSelf && !activatedObjects.Contains(obj))
            {
                inactiveObjects.Add(obj);
            }
        }

        // Ȱ��ȭ���� ���� ������Ʈ�� ������ ��� ������Ʈ�� �ٽ� �ʱ�ȭ�ϰ� �ڷ�ƾ�� ������մϴ�.
        if (inactiveObjects.Count == 0)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(false);
            }
            activatedObjects.Clear();
            StartActivationCoroutine();
            yield break;
        }

        // Ȱ��ȭ���� ���� ������Ʈ �߿��� �����ϰ� ������Ʈ�� �����Ͽ� Ȱ��ȭ�մϴ�.
        int randomIndex = Random.Range(0, inactiveObjects.Count);
        GameObject selectedObject = inactiveObjects[randomIndex];
        selectedObject.SetActive(true);
        activatedObjects.Add(selectedObject);

        // ���� ������Ʈ�� Ȱ��ȭ�� �� ���� ������Ʈ�� ��Ȱ��ȭ�ϵ��� �ڷ�ƾ�� ������մϴ�.
        StartActivationCoroutine();
    }

}