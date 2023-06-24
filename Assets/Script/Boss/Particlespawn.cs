using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlespawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ��ȯ�� ��� �����յ�
    public float spawnInterval = 1f; // ��ȯ ���� (��)
    public float spawnRadius = 5f; // ��ȯ ��ġ �ݰ�

    public AudioClip craklesoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void OnDisable()
    {
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        // �������� ��� ������ ����
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];

        // �ֺ� ���� ��ġ ���
        Vector2 bossPosition = transform.position;
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector2 spawnPosition = bossPosition + randomOffset;

        // ��� ����
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        audioSource.PlayOneShot(craklesoundClip);
    }

    //private IEnumerator SpawnEnemies()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnInterval);

    //        // �������� ��� ������ ����
    //        int randomIndex = Random.Range(0, enemyPrefabs.Length);
    //        GameObject enemyPrefab = enemyPrefabs[randomIndex];

    //        // �ֺ� ���� ��ġ ���
    //        Vector2 bossPosition = transform.position;
    //        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
    //        Vector2 spawnPosition = bossPosition + randomOffset;

    //        // ��� ����
    //        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    //    }
    //}

}
