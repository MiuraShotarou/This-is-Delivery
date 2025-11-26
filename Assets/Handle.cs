using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 100f;
    void Update()
    {
#if UNITY_STANDALONE_WIN
        float turnInput = Input.GetAxis("Horizontal");
#elif UNITY_IOS || UNITY_ANDROID
        // 端末の傾きからハンドリングを取得
        Quaternion adjustScreenOrientation = new Quaternion(0, 0, 90, 0);
        float turnInput = (Input.gyro.attitude * adjustScreenOrientation).x;
#endif
        transform.Rotate(0f, turnInput * _turnSpeed * Time.deltaTime, 0f);
    }
}
