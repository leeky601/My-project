using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 Prefab
    public float bulletSpeed = 10f; // 총알 속도
    public float fireRate = 0.5f; // 발사 간격

    private float nextFire = 0f; // 다음 발사 가능 시간

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            // 총알 Prefab 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 총알 발사 방향 계산
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.Normalize();

            // 총알 발사
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction * bulletSpeed;
        }
    }
}