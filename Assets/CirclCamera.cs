using UnityEngine;
using System.Collections.Generic;

class CircleCamera : MonoBehaviour
{
    Camera _mainCamera;
    Vector3[] _circlePointArray;
    Vector3 _center = new (0, -7.43f, 5.33f);
    float _radius = 15.29f;
    int _segments = 360;
    int _circlePointIndex = 0;

    void Awake()
    {
        _circlePointArray = GetCirclePoints(_center, _radius, _segments);
        _mainCamera = Camera.main;
    }

    void Update()
    {
        RotationCamera();
    }

    void RotationCamera()
    {
        _mainCamera.transform.position = _circlePointArray[_circlePointIndex];
        _circlePointIndex++;
    }
    
    public Vector3[] GetCirclePoints(Vector3 center, float radius, int segments) //中点、半径、点同士の間隔
    {
        var pts = new Vector3[segments + 1]; // 最後を中心の最初と同じにするなら +1
        for (int i = 0; i < segments; i++)
        {
            float theta = (2f * Mathf.PI * i) / segments;
            float x = center.x + Mathf.Cos(theta) * radius;
            float z = center.z + Mathf.Sin(theta) * radius; // 2Dなら y を使う
            pts[i] = new Vector3(x, center.y, z);
        }
        pts[segments] = pts[0]; // 閉ループにする場合
        return pts;
    }
}