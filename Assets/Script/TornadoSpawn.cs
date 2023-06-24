using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpawn : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnInterval = 15f; // ���� ����

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // Ÿ�̸� ���� ���ҽ�ŵ�ϴ�.

        if (timer <= 0f)
        {
            SpawnPrefab();
            timer = spawnInterval; // Ÿ�̸Ӹ� �ٽ� ���� �������� �����մϴ�.
        }
    }
    private void SpawnPrefab()
    {
        // �������� ���� ��ġ�� �����մϴ�.
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
