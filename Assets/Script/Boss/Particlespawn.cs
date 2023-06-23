using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlespawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ��ȯ�� ��� �����յ�
    public float spawnInterval = 5f; // ��ȯ ���� (��)
    public float spawnRadius = 5f; // ��ȯ ��ġ �ݰ�

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // �������� ��� ������ ����
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // �ֺ� ���� ��ġ ���
            Vector2 bossPosition = transform.position;
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = bossPosition + randomOffset;

            // ��� ����
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
