using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATK2_Spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;

    private Transform player;
    private float nextFireTime;
    Vector2 lookDirection_1;
    Vector2 lookDirection_2;
    Vector2 lookDirection_3;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lookDirection_1 = player.position - transform.position;
        lookDirection_2 = new Vector2(player.position.x - transform.position.x + 2f, player.position.y - transform.position.y + 2f);
        lookDirection_3 = new Vector2(player.position.x - transform.position.x - 2f, player.position.y - transform.position.y - 2f);

        Destroy(gameObject, 5f);  
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 lookDirection = player.position - transform.position;
        

        // ���� �ð����� �Ѿ��� �߻��մϴ�.
        if (Time.time >= nextFireTime)
        {
            // �߻� ������ Ÿ���� ������Ʈ�մϴ�.
            nextFireTime = Time.time + fireRate;

            // �Ѿ��� �߻��մϴ�.
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = lookDirection_1.normalized * bulletSpeed;


            Vector2 spawnPosition_2 = transform.position + new Vector3(1.5f, 0f, 0f);
            GameObject bullet_1 = Instantiate(bulletPrefab, spawnPosition_2, transform.rotation);
            bullet_1.GetComponent<Rigidbody2D>().velocity = lookDirection_2.normalized * bulletSpeed;

            Vector2 spawnPosition_3 = transform.position + new Vector3(-1.5f, 0f, 0f);
            GameObject bullet_2 = Instantiate(bulletPrefab, spawnPosition_3, transform.rotation);
            bullet_2.GetComponent<Rigidbody2D>().velocity = lookDirection_3.normalized * bulletSpeed;

        }
    }
}

