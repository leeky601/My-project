using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 10f; // ������ �̵� �ӵ�

    private Vector3 direction; // ������ �߻� ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
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
