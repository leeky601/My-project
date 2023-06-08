using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergenerator : MonoBehaviour
{
    public Transform sphereTransform;   // ��ü ������Ʈ�� Transform ������Ʈ
    public Transform playerTransform;   // �ʷ��̾� ������Ʈ�� Transform ������Ʈ
    public GameObject stickPrefab;      // ����� ������
    private GameObject stickInstance;    // ������ ����� �ν��Ͻ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spherePosition = sphereTransform.position;
        Vector3 playerPosition = playerTransform.position;

        // ������� ���̿� ������ ����մϴ�.
        Vector3 stickDirection = playerPosition - spherePosition;
        float stickLength = stickDirection.magnitude;

        // ����� �ν��Ͻ��� ������ �����մϴ�.
        if (stickInstance == null)
        {
            stickInstance = Instantiate(stickPrefab, spherePosition, Quaternion.identity);
        }
        // ����� �ν��Ͻ��� ������ ��ġ�� ������ ������Ʈ�մϴ�.
        else
        {
            stickInstance.transform.position = spherePosition + stickDirection / 2f;
            stickInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, stickDirection);
            // ������� ���̸� �����մϴ�.
            stickInstance.transform.localScale = new Vector3(1f, stickLength, 1f);
        }
    }
}

