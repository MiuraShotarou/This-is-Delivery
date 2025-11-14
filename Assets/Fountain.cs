using UnityEngine;
public class ParticleReverseAtPosition : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _reversePositionX = 5f; // 反転位置
    [SerializeField] private bool _reverseOnX = true;
    [SerializeField] private bool _reverseOnY = false;
    [SerializeField] private bool _reverseOnZ = false;
    
    private ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles;
    
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }
    
    void LateUpdate()
    {
        // ✅ 現在のパーティクルを取得
        int particleCount = _particleSystem.GetParticles(_particles);
        
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 velocity = _particles[i].velocity;
            Vector3 position = _particles[i].position;
            
            // ✅ X軸で反転
            if (_reverseOnX && Mathf.Abs(position.x) > _reversePositionX)
            {
                velocity.x = -velocity.x;
                _particles[i].velocity = velocity;
            }
            
            // ✅ Y軸で反転
            if (_reverseOnY && Mathf.Abs(position.y) > _reversePositionX)
            {
                velocity.y = -velocity.y;
                _particles[i].velocity = velocity;
            }
            
            // ✅ Z軸で反転
            if (_reverseOnZ && Mathf.Abs(position.z) > _reversePositionX)
            {
                velocity.z = -velocity.z;
                _particles[i].velocity = velocity;
            }
        }
        
        // ✅ パーティクルを更新
        _particleSystem.SetParticles(_particles, particleCount);
    }
}
