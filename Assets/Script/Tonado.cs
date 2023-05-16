using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonado : MonoBehaviour
{
    public float pullForce = 5f; // 끌어당기는 힘의 강도
    public float rotationSpeed = 50f; // 회전 속도

    public Transform player; // 플레이어의 Transform 컴포넌트
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
        if (other.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인 경우
        {
            player = other.transform; // 플레이어의 Transform 컴포넌트를 저장
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인 경우
        {
            // 중심에서 플레이어까지의 방향 벡터와, 회전 축 벡터를 계산
            Vector2 pullDirection = transform.position - player.position;
            Vector3 rotationAxis = Vector3.forward;

            // 회전과 끌어당기는 힘을 적용
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
            player.GetComponent<Rigidbody2D>().AddForce(pullDirection.normalized * pullForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 충돌한 오브젝트가 플레이어인 경우
        {
            player = null; // 플레이어 변수 초기화
        }
    }
}
