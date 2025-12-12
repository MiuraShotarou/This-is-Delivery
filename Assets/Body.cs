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
                Boost();
                break;
            case CarState.BoostStay:
                BoostStay();
                break;
            case CarState.BoostAttenuation:
                BoostAttenuation();
                SpeedCheck();
                break;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 車同士が衝突するとお互いに反発し合う
        if (collision.gameObject.CompareTag("Cart"))
        {
            if (_timer.IsCanAddForce)
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

    void Boost()
    {
        // ブースト処理
        float boostAdditve = GameDataManager.Instance.BoostAddtive;
        _engine.CurrentSpeed += boostAdditve;
        _engine.TheoreticallySpeed += boostAdditve;
        // タイマーのスタート
        _timer.InitAddForceParam();
        // BoostStay中はTimer.Updateを監視する
        CarState = CarState.BoostStay;
        //基礎スピード + ピザ + ペッパー
    }

    void BoostStay()
    {
        if (_timer.IsCanAttenuation)
        {
            CarState = CarState.BoostAttenuation;
        }
    }
    /// <summary> 減速処理 </summary>
    void BoostAttenuation() => _engine.CurrentSpeed -= GameDataManager.Instance.AttenuationMultiplier;
    /// <summary> 現在の速度があるべき速度よりも下回っていた際に、正しいスピードへ戻すための関数 </summary>
    void SpeedCheck()
    {
        if (_engine.CurrentSpeed < _engine.TheoreticallySpeed)
        {
            _engine.CurrentSpeed = _engine.TheoreticallySpeed;
            CarState = CarState.Normal; //誤作動の危険
        }
    }
}