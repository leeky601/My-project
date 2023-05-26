using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private float timer; // 레이저 발사까지 남은 시간
    private Transform playerTransform; // 플레이어의 위치
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTimerAndPlayerTransform(float delay, Transform player)
    {
        timer = delay;
        playerTransform = player;
        Invoke("ShootLaser", timer);
    }

    void ShootLaser()
    {
        // 플레이어 위치로 레이저 발사
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        // 레이저 발사 로직 추가
        // ...

        Destroy(gameObject); // 구체 제거
    }
}
