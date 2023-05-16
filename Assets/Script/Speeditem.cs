using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeditem : MonoBehaviour
{
   

    private PlayerMove playerController; // �÷��̾� ��Ʈ�ѷ�
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerMove>();
            if (playerController != null && playerController.speed == 3.0f)
            {
                playerController.StartSpeedBoost();
                // ������ ȿ�� ����
                Destroy(gameObject);
                
            }
        }
    }
    

}
