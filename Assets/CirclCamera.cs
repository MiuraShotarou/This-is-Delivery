using UnityEngine;

class CircleCamera : MonoBehaviour
{
    Camera _mainCamera;
    Vector3[] _circlePointArray;
    Vector3[] _circleRotationArray;
    Vector3 _center = new (0, -0.26f, 5.33f); //y == -7.43f
    float _radius = 15.29f;
    int _segments = 720;
    int _circlePointIndex = 0;
    int _CirclePointIndex
    {
        get => _circlePointIndex;
        set {
            _circlePointIndex = value;
            if (_circlePointIndex > _segments - 1)
            {
                _circlePointIndex = 0;
            }}
    }
    Vector3 _circleRotation;

    void Awake()
    {
        _mainCamera = Camera.main;
        _circlePointArray = GetCirclePoints(_center, _radius, _segments);
        _circleRotation = _mainCamera.transform.rotation.eulerAngles;
        _circleRotationArray = GetCircleRotation(_segments);
    }

    void Update()
    {
        RotationCamera();
    }

    void RotationCamera()
    {
        _mainCamera.transform.position = _circlePointArray[_CirclePointIndex];
        _mainCamera.transform.rotation = Quaternion.Euler(_circleRotationArray[_circlePointIndex]);
        _CirclePointIndex++;
    }
    
    Vector3[] GetCirclePoints(Vector3 center, float radius, int segments)
    {
        Vector3[] posArray = new Vector3[segments];
        for (int i = 0; i < segments; i++)
        {
            float theta = 2f * Mathf.PI * i / segments; //theta == 円の中心から見た角度ラジアン　最初のラジアンは0
            float x = center.x + Mathf.Sin(theta) * radius;
            float z = center.z + Mathf.Cos(theta) * radius;
            posArray[i] = new Vector3(x, center.y, z);
        }
        return posArray;
    }

    Vector3[] GetCircleRotation(int segments)
    {
        Vector3[] rotArray = new Vector3[segments];
        float angle = 180f;
        float addAngle = 360f / segments;
        int turningPoint = segments / 2 - 1;
        for (int i = 0; i < segments; i++)
        {
            _circleRotation.y = angle;
            rotArray[i] = _circleRotation;
            angle = i == turningPoint? 0 : angle + addAngle;
        }
        return rotArray;
    }
}