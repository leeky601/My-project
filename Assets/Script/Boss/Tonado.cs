using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonado : MonoBehaviour
{
    public float pullForce = 5f; // ������� ���� ����
    public bool isPlayerTriggered = false;
    Transform player; // �÷��̾��� Transform ������Ʈ
    public float speed = 5f;

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ATKsoundClip);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
        Destroy(gameObject, 10.0f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            player = other.transform; // �÷��̾��� Transform ������Ʈ�� ����
            isPlayerTriggered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            // �߽ɿ��� �÷��̾������ ���� ���Ϳ�, ȸ�� �� ���͸� ���
            Vector2 pullDirection = transform.position - player.position;
           
            // ȸ���� ������� ���� ����
           
            player.GetComponent<Rigidbody2D>().AddForce(pullDirection.normalized * pullForce);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // �浹�� ������Ʈ�� �÷��̾��� ���
        {
            player = null; // �÷��̾��� Transform ������Ʈ�� ����
            isPlayerTriggered = false;
        }
    }

    private void OnDestroy()
    {
        if(isPlayerTriggered)
       {

       }
    }

}
