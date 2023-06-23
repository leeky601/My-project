using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트 배열
    public float minTime = 10f; // 최소 시간 간격
    

    private Coroutine activationCoroutine;
    private List<GameObject> activatedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 모든 오브젝트를 비활성화합니다.
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

    }

    private void StartActivationCoroutine()
    {
        // 랜덤한 시간 간격을 계산합니다.
        

        // 이전에 실행 중인 코루틴이 있다면 중지합니다.
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }

        // 지정된 시간 간격 후에 오브젝트 활성화 코루틴을 시작합니다.
        activationCoroutine = StartCoroutine(ActivateObjectAfterDelay(minTime));
    }

    private IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 활성화되지 않은 오브젝트를 필터링합니다.
        List<GameObject> inactiveObjects = new List<GameObject>();
        foreach (GameObject obj in objectsToActivate)
        {
            if (!obj.activeSelf && !activatedObjects.Contains(obj))
            {
                inactiveObjects.Add(obj);
            }
        }

        // 활성화되지 않은 오브젝트가 없으면 모든 오브젝트를 다시 초기화하고 코루틴을 재시작합니다.
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

        // 활성화되지 않은 오브젝트 중에서 랜덤하게 오브젝트를 선택하여 활성화합니다.
        int randomIndex = Random.Range(0, inactiveObjects.Count);
        GameObject selectedObject = inactiveObjects[randomIndex];
        selectedObject.SetActive(true);
        activatedObjects.Add(selectedObject);

        // 다음 오브젝트가 활성화될 때 이전 오브젝트를 비활성화하도록 코루틴을 재시작합니다.
        StartActivationCoroutine();
    }

}