using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : MonoBehaviour
{
    public GameObject spawnPrefab; // ������ ������
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnPrefabInCenter();
            Destroy(gameObject);
        }
    }

    private void SpawnPrefabInCenter()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // �� �߾� ��ġ�� �������ּ���.
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(spawnPrefab, spawnPosition, spawnRotation);
    }
}
