using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtkSpawn : MonoBehaviour
{
    public GameObject prefab; // ������ ������
    public float spawnRadius = 5f; // ���� �ݰ�

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnPrefabNearPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefabNearPlayer()
    {
        // �÷��̾� �ֺ����� ������ ��ġ�� �����մϴ�.
        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + randomOffset;

        // ������ ��ġ�� �������� �����մϴ�.
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}

