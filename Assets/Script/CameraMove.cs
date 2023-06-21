using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove: MonoBehaviour
{
    public Transform target;  // ī�޶� ����ٴ� ���
    public float maxY;       // ���� y ��� �� (���)
    public float minY;       // ���� y ��� �� (�ϴ�)

    private void LateUpdate()
    {
        // ī�޶��� ��ġ�� ����� y ��ġ�� �°� �����մϴ�.
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
