using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBiggerAtk : MonoBehaviour
{
    public Transform player; 
    public float speed = 5f; 
    public float scaleSpeed = 0.1f; 
    private CircleCollider2D circleCollider;
    private float initialRadius; 

    public AudioClip ATKsoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ATKsoundClip);


        initialRadius = circleCollider.radius; //�� ũ�� ����
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime); //�÷��̾� ����
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, 0f) * Time.deltaTime; //ũ�� ����

       
        float scaleFactor = transform.localScale.x; 
        circleCollider.radius = initialRadius * scaleFactor * 1.5f;  //collider ũ�� ����

        Destroy(gameObject, 2.0f);
    }
}
