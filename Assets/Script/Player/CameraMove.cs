using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove: MonoBehaviour
{
    public Transform target;  // ī�޶� ����ٴ� ���
    public float maxY;       
    public float minY;      

    private void LateUpdate()
    {
        // ī�޶� �̵�
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
