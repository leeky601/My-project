using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonado : MonoBehaviour
{
    public float pullForce = 5f; // ������� ���� ����
    public float rotationSpeed = 50f; // ȸ�� �ӵ�

    public Transform player; // �÷��̾��� Transform ������Ʈ
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            player = other.transform; // �÷��̾��� Transform ������Ʈ�� ����
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            // �߽ɿ��� �÷��̾������ ���� ���Ϳ�, ȸ�� �� ���͸� ���
            Vector2 pullDirection = transform.position - player.position;
            Vector3 rotationAxis = Vector3.forward;

            // ȸ���� ������� ���� ����
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            player.GetComponent<Rigidbody2D>().AddForce(pullDirection.normalized * pullForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            player = null; // �÷��̾� ���� �ʱ�ȭ
        }
    }
}
