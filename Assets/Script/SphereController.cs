using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private float timer; // ������ �߻���� ���� �ð�
    private Transform playerTransform; // �÷��̾��� ��ġ
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
        // �÷��̾� ��ġ�� ������ �߻�
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        // ������ �߻� ���� �߰�
        // ...

        Destroy(gameObject); // ��ü ����
    }
}
