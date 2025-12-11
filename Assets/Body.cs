using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    [SerializeField] private float _weight;
    public float Weight { get => _weight; set => _weight = value; }
    Rigidbody _rigidbody;
    Timer _timer;
    Engine _engine;
    CarState _carState;
    // public Engine Engine {set => _engine = value; }
    public CarState CarState {set => _carState = value; }
    void Awake()
    {
        _timer = GetComponent<Timer>();
        _engine = GetComponent<Engine>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    /// <summary>　ステートマシン　</summary>
    void Update()
    {
        switch (_carState)
        {
            case CarState.Stop: //
                break;
            case CarState.Normal:
                break;
            case CarState.DriftLow:
                break;            
            case CarState.DriftHigh:
                break;
            case CarState.Boost:
                break;
            case CarState.BoostAttenuation:
                BoostAttenuation();
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 車同士が衝突するとお互いに反発し合う
        if (collision.gameObject.CompareTag("Cart"))
        {
            if (_timer._CanAddForce)
            {
                AddForce(collision.gameObject.GetComponent<Body>());
                _timer.InitAddForceParam();
            }
        }
    }
    void AddForce(Body body)
    {
        Vector3 reverse = -_rigidbody.velocity;
        float forcePower = body.Weight - Weight + GameDataManager.Instance.CarStateMultiplier[(int)_carState];
        _rigidbody.AddForce(reverse * forcePower, ForceMode.Impulse);
    }
    void BoostAttenuation() => _engine.CurrentSpeed -= 
}