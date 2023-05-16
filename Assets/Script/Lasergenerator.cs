using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergenerator : MonoBehaviour
{
    public Transform sphereTransform;   // 구체 오브젝트의 Transform 컴포넌트
    public Transform playerTransform;   // 필레이어 오브젝트의 Transform 컴포넌트
    public GameObject stickPrefab;      // 막대기 프리팹
    private GameObject stickInstance;    // 생성된 막대기 인스턴스
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spherePosition = sphereTransform.position;
        Vector3 playerPosition = playerTransform.position;

        // 막대기의 길이와 방향을 계산합니다.
        Vector3 stickDirection = playerPosition - spherePosition;
        float stickLength = stickDirection.magnitude;

        // 막대기 인스턴스가 없으면 생성합니다.
        if (stickInstance == null)
        {
            stickInstance = Instantiate(stickPrefab, spherePosition, Quaternion.identity);
        }
        // 막대기 인스턴스가 있으면 위치와 방향을 업데이트합니다.
        else
        {
            stickInstance.transform.position = spherePosition + stickDirection / 2f;
            stickInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, stickDirection);
            // 막대기의 길이를 조정합니다.
            stickInstance.transform.localScale = new Vector3(1f, stickLength, 1f);
        }
    }
}

