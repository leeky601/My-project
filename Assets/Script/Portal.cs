using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int nextSceneNumber; // ���� ���� ��ȣ�� ������ ����

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
            int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;

            int nextSceneIndex = (currentSceneNumber + nextSceneNumber) % totalSceneCount;

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}