using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBiggerAtk : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ü
    public float speed = 5f; // �̵� �ӵ�
    public float scaleSpeed = 0.1f; // ũ�� ��ȭ �ӵ�
    private CircleCollider2D circleCollider;
    private float initialRadius; // �ʱ� ������

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ATKsoundClip);


        initialRadius = circleCollider.radius; // �ʱ� ������ ����
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0f) * Time.deltaTime;

        // �����Ͽ� ���� CircleCollider2D�� ������ ����
        float scaleFactor = transform.localScale.x; // x�� �������� �������� ����
        circleCollider.radius = initialRadius * scaleFactor * 1.5f; // �ʱ� �������� ������ ����

        Destroy(gameObject, 2.0f);
    }
}
