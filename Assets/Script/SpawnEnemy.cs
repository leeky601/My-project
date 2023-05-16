using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public float spawnDelay = 0f; // 최초 생성 딜레이
    public float spawnInterval = 5f; // 생성 주기
    public float spawnRadius = 5f; // 생성 반경
    public float minDistanceToPlayer = 10f; // 플레이어와의 최소 거리
    public GameObject spawnAreaObject; // 생성 영역 오브젝트
    private Rect spawnArea; // 생성 영역

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

        // 생성 영역에서 랜덤한 위치를 구합니다
        float x = Random.Range(spawnArea.xMin, spawnArea.xMax);
        float z = Random.Range(spawnArea.yMin, spawnArea.yMax);
        spawnPos = new Vector3(x, 0f, z);

        // 생성된 위치가 플레이어와의 최소 거리 이상인지 확인합니다
        while (Vector3.Distance(spawnPos, playerPos) < minDistanceToPlayer)
        {
            x = Random.Range(spawnArea.xMin, spawnArea.xMax);
            z = Random.Range(spawnArea.yMin, spawnArea.yMax);
            spawnPos = new Vector3(x, 0f, z);
        }

        // 적을 생성합니다
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

}
