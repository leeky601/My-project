using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject laserPrefab;
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

        // �������� �߻��� ��ġ ��� (��ü�� ���� ��ġ)
        Vector3 laserSpawnPosition = transform.position;

        // �������� �����ϰ� �߻��մϴ�.
        GameObject laser = Instantiate(laserPrefab, laserSpawnPosition, Quaternion.identity);
        laser.GetComponent<LaserController>().SetDirection(direction);


        Destroy(gameObject); // ��ü ����
    }
}
