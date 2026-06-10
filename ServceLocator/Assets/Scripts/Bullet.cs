using System.Collections;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _lifetime = 3f;
    [SerializeField] float _homingRadius = 3f;
    [SerializeField] LayerMask _obstacleLayer;
    ITargetProvider _target;
    ISoundPlayer _soundPlayer;
    Bullet.Pool _pool;
    Coroutine _lifetimeCoroutine;
    Vector3 _direction;

    [Inject]
    public void Construct(ITargetProvider target, ISoundPlayer soundPlayer)
    {
        _target = target;
        _soundPlayer = soundPlayer;
    }

    public void OnSpawned(Vector3 position, Vector3 direction, Bullet.Pool pool)
    {
        transform.position = position;
        _direction = direction;
        _pool = pool;
        _lifetimeCoroutine = StartCoroutine(LifetimeRoutine());
    }

    void Update() => MoveLogic();

    void MoveLogic()
    {
        if (_target.IsActive)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(transform.position, _homingRadius, _obstacleLayer);
            if (obstacle == null)
            {
                Vector3 targetDir = (_target.Position - transform.position).normalized;
                _direction = Vector3.Lerp(_direction, targetDir, Time.deltaTime * 5f);
            }
        }
        transform.position += _direction * (_speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out DestructibleObstacle obstacle))
        {
            obstacle.DestroyObstacle();
            _soundPlayer.PlayHitSound();
        }
        Despawn();
    }

    IEnumerator LifetimeRoutine()
    {
        yield return new WaitForSeconds(_lifetime);
        Despawn();
    }

    void Despawn()
    {
        if (_lifetimeCoroutine != null) StopCoroutine(_lifetimeCoroutine);
        _pool.Despawn(this);
    }

    public class Pool : MonoMemoryPool<Vector3, Vector3, Bullet>
    {
        protected override void Reinitialize(Vector3 position, Vector3 direction, Bullet bullet) => bullet.OnSpawned(position, direction, this);
    }
}