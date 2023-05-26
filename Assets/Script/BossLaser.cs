using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject spherePrefab; // ��ü ������
    public float spawnInterval = 5f; // ��ü ���� ����
    public float spawnRadius = 5f; // ��ȯ ��ġ �ݰ�
    public float laserDelay = 2f; // ��ü ���� �� ������ �߻������ �ð� ����

    private Transform playerTransform; // �÷��̾��� ��ġ
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnSphere", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnSphere()
    {
        // ���� �ֺ� ������ ��ġ ���
        Vector3 randomPosition = CalculateRandomPosition();

        // ��ü ���� �� ��ġ �̵�
        GameObject sphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
        sphere.GetComponent<SphereController>().SetTimerAndPlayerTransform(laserDelay, playerTransform);
    }

    Vector3 CalculateRandomPosition()
    {
        // ���� ��ġ�� �������� ������ ���� ������ ������ ��ġ�� ����մϴ�.
        Vector3 bossPosition = transform.position; // ������ ��ġ
        float radius = 5f; // ������ ����

        // ������ ������ ����մϴ�.
        float randomAngle = Random.Range(0f, 360f);
        // ������ ��ġ�� ����մϴ�.
        Vector3 randomOffset = Quaternion.Euler(0f, 0f, randomAngle) * Vector3.right * radius;
        // ���� ��ġ�� ������ �������� �ջ��Ͽ� ���� ��ġ�� ����մϴ�.
        Vector3 randomPosition = bossPosition + randomOffset;

        return randomPosition;
    }
}
