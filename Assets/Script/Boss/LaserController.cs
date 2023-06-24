using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10f; // ������ �̵� �ӵ�

    private Vector3 direction; // ������ �߻� ����

    public AudioClip LasersoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(LasersoundClip);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �������� �浹�� ��� �߰� ������ �����մϴ�.
        // �浹 ó�� ���� �߰�
        // ...

        Destroy(gameObject); // ������ ����
    }
}
