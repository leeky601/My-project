using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdrop : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 드롭될 아이템 프리팹들
    public float dropProbability = 0.5f; // 아이템이 드롭될 확률
    // Start is called before the first frame update
    void Start()
    {
        
        if (Random.value <= dropProbability)
        {
            // 아이템을 랜덤으로 선택하여 드롭합니다.
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
