using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 100f;
    
    void Update()
    {
        float turnInput = Input.GetAxis("Horizontal");
        transform.Rotate(0f, turnInput * _turnSpeed * Time.deltaTime, 0f);
    }
}
