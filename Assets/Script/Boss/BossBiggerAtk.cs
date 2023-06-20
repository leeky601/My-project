using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBiggerAtk : MonoBehaviour
{
    public Transform player; // 플레이어 객체
    public float speed = 5f; // 이동 속도
    public float scaleSpeed = 0.1f; // 크기 변화 속도
    private CircleCollider2D circleCollider;
    private float initialRadius; // 초기 반지름

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ATKsoundClip);


        initialRadius = circleCollider.radius; // 초기 반지름 저장
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0f) * Time.deltaTime;

        // 스케일에 따라 CircleCollider2D의 반지름 조정
        float scaleFactor = transform.localScale.x; // x축 스케일을 기준으로 가정
        circleCollider.radius = initialRadius * scaleFactor * 1.5f; // 초기 반지름에 스케일 적용

        Destroy(gameObject, 2.0f);
    }
}
