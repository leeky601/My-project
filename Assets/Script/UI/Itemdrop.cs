using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Itemdrop : MonoBehaviour
{
    public GameObject[] itemPrefabs; // ��ӵ� ������ �����յ�
    private float dropProbability = 0.7f; // �������� ��ӵ� Ȯ��
    // Start is called before the first frame update
    void Start()
    {
        float rd; 
        rd = Random.value;
        
        if (rd <= dropProbability)
        {
            if (rd < 0.15f && SceneManager.GetActiveScene().name != "Boss")
            {
                GameObject item = Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
            }
            else
            {
                int randomIndex = Random.Range(0, 2);
                GameObject item = Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity);
            }
            // �������� �������� �����Ͽ� ����մϴ�.
        }
        Destroy(gameObject, 2.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
