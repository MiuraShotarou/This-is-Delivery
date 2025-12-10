using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    [SerializeField] private int _weight;
    public int Weight { set { _weight = value; } }
    Rigidbody _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _forcePower = 100f;
        _resetTimer = 0f;
        _dontAddForceTimePoint = 1f;
    }
    void Update()
    {
        _resetTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        // 車同士が衝突するとお互いに反発し合う
        if (collision.gameObject.CompareTag("Cart"))
        {
            if (_resetTimer > _dontAddForceTimePoint)
            {
                AddForce();
            }
        }
    }
    void AddForce()
    {
        Debug.Log("AddingForce");
        Vector3 reverse = -_rigidbody.velocity;
        _rigidbody.AddForce(reverse * _forcePower, ForceMode.Impulse);
        _resetTimer = 0;
    }
    float _forcePower;
    float _resetTimer;
    float _dontAddForceTimePoint;
}