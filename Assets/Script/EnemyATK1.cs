using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK1 : MonoBehaviour
{
    public Transform player; // 플레이어 객체
    public float speed = 5f; // 이동 속도
    public float scaleSpeed = 0.1f; // 크기 변화 속도

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
