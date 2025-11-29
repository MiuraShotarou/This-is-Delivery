using System;
using UnityEngine;
/// <summary>
/// 視錐台カリングを利用したカメラに映らない範囲にあるオブジェクトの描画範囲制限
/// </summary>
class FrustumCulling : MonoBehaviour
{
    Plane[] _planeArray; //Plane == 法線 + 距離 (vector3, float)
    Renderer[] _rendererArray; //Bounds == 中心座標 + サイズ (Vector3, Vector3)
    Camera _camera;

    void Awake()
    {
        _camera = Camera.main;
        _planeArray = GeometryUtility.CalculateFrustumPlanes(_camera);
        _rendererArray = FindObjectsOfType<Renderer>();
    }
    void Update()
    {
        Array.Resize(ref _planeArray, 4); //near,far面は要らないので排除。
        _planeArray = GeometryUtility.CalculateFrustumPlanes(_camera);
        foreach (Renderer renderer in _rendererArray)
        {
            if (GeometryUtility.TestPlanesAABB(_planeArray, renderer.bounds)) //カメラの描画範囲内であれば
            {
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
        }
    }
}