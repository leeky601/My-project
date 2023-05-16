using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // �� ������
    public float spawnDelay = 0f; // ���� ���� ������
    public float spawnInterval = 5f; // ���� �ֱ�
    public float spawnRadius = 5f; // ���� �ݰ�
    public float minDistanceToPlayer = 10f; // �÷��̾���� �ּ� �Ÿ�
    public GameObject spawnAreaObject; // ���� ���� ������Ʈ
    private Rect spawnArea; // ���� ����

    void Start()
    {
        Vector3 position = spawnAreaObject.transform.position;
        Vector3 scale = spawnAreaObject.transform.localScale;
        spawnArea = new Rect(position.x - scale.x / 2f, position.z - scale.z / 2f, scale.x, scale.z);
        InvokeRepeating("Spawn", spawnDelay, spawnInterval);
    }

    void Spawn()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 spawnPos = Vector3.zero;

        // ���� �������� ������ ��ġ�� ���մϴ�
        float x = Random.Range(spawnArea.xMin, spawnArea.xMax);
        float z = Random.Range(spawnArea.yMin, spawnArea.yMax);
        spawnPos = new Vector3(x, 0f, z);

        // ������ ��ġ�� �÷��̾���� �ּ� �Ÿ� �̻����� Ȯ���մϴ�
        while (Vector3.Distance(spawnPos, playerPos) < minDistanceToPlayer)
        {
            x = Random.Range(spawnArea.xMin, spawnArea.xMax);
            z = Random.Range(spawnArea.yMin, spawnArea.yMax);
            spawnPos = new Vector3(x, 0f, z);
        }

        // ���� �����մϴ�
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

}
