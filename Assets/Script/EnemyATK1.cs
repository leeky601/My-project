using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK1 : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ü
    public float speed = 5f; // �̵� �ӵ�
    public float scaleSpeed = 0.1f; // ũ�� ��ȭ �ӵ�

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0f) * Time.deltaTime;
        Destroy(gameObject, 3.0f);

    }
}
