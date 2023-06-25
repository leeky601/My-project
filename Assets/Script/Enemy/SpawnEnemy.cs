using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public float spawnDelay = 0f; 
    public float spawnInterval = 5f; 
    public float minDistanceToPlayer = 10f; 
    public GameObject spawnAreaObject; 
    private Rect spawnArea; 

   
    void Start()
    {
        Vector3 position = spawnAreaObject.transform.position; //��ȯ ��ġ
        Vector3 scale = spawnAreaObject.transform.localScale; //��ȯ ����
        spawnArea = new Rect(position.x - scale.x / 2f, position.z - scale.z / 2f, scale.x, scale.z); //��ȯ ���� ����
        InvokeRepeating("Spawn", spawnDelay, spawnInterval); //���� �������� ��ȯ
    }

    void Spawn()
    {
        if (!gameObject.activeSelf)
        {
            return; 
        }

        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 spawnPos = Vector3.zero;

        // ��ȯ �����ȿ��� ���� ��ġ ����
        float x = Random.Range(spawnArea.xMin, spawnArea.xMax);
        float z = Random.Range(spawnArea.yMin, spawnArea.yMax);
        spawnPos = new Vector3(x, 0f, z);  

        // �÷��̾�� �ּ� �Ÿ� ����
        while (Vector3.Distance(spawnPos, playerPos) < minDistanceToPlayer)
        {
            x = Random.Range(spawnArea.xMin, spawnArea.xMax);
            z = Random.Range(spawnArea.yMin, spawnArea.yMax);
            spawnPos = new Vector3(x, 0f, z);
        }

        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; //���� �� ����
        Instantiate(randomEnemyPrefab, spawnPos, Quaternion.identity); //���� �� ��ȯ

    }

}
