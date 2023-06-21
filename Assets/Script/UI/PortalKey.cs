using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalKey : MonoBehaviour
{
    public GameObject spawnPrefab; // ������ ������
    private GameObject spawner;
    public string targetTag;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawner != null)
            {
                spawner.SetActive(false); // LifeText ������Ʈ�� ��Ȱ��ȭ
            }

            DestroyObjectsWithTag();
            SpawnPrefabInCenter();
            Destroy(gameObject);
        }
    }
    private void DestroyObjectsWithTag()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }
    private void SpawnPrefabInCenter()
    {
        Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // �� �߾� ��ġ�� �������ּ���.
        Quaternion spawnRotation = Quaternion.identity;

        Instantiate(spawnPrefab, spawnPosition, spawnRotation);
    }
}
