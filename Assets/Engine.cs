using UnityEngine;

public class Engine : MonoBehaviour
{
    private GameObject _playerObj;
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
