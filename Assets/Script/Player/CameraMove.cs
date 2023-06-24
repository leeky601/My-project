using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove: MonoBehaviour
{
    public Transform target;  // 카메라가 따라다닐 대상
    public float maxY;       // 맵의 y 경계 값 (상단)
    public float minY;       // 맵의 y 경계 값 (하단)

    private void LateUpdate()
    {
        // 카메라의 위치를 대상의 y 위치에 맞게 조정합니다.
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
