using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdrop : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ��ӵ� ������ �����յ�
    public float dropProbability = 0.5f; // �������� ��ӵ� Ȯ��
    // Start is called before the first frame update
    void Start()
    {
        
        if (Random.value <= dropProbability)
        {
            // �������� �������� �����Ͽ� ����մϴ�.
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            GameObject item = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
        }
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
