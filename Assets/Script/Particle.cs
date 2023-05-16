using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float delay = 2f;
    public GameObject candyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnPrefab", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPrefab()
    {
        Instantiate(candyPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
