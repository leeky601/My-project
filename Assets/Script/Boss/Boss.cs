using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject[] enemyPrefabs; // 소환할 잡몹 프리팹들
    public float spawnInterval = 5f; // 소환 간격 (초)
    public float spawnRadius = 5f; // 소환 위치 반경
    public GameObject spherePrefab; // 소환할 구체 프리팹

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnSphere());
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

            // 랜덤으로 잡몹 프리팹 선택
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // 주변 랜덤 위치 계산
            Vector2 bossPosition = transform.position;
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = bossPosition + randomOffset;

            // 잡몹 생성
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator SpawnSphere()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            

            // 주변 랜덤 위치 계산
            Vector2 bossPosition = transform.position;
            Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
            Vector2 spawnPosition = bossPosition + randomOffset;

            // 잡몹 생성
            Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        }
    }
}