using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _playerTarget;
    [SerializeField] private int damage;

    private static readonly int _isDead = Animator.StringToHash("IsDead");
    private readonly float _dieDelay = 10f;

    private Animator _animator;

    public Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Health.ValueZeroReached += OnValueZeroReached;
    }

    private void OnDisable()
    {
        Health.ValueZeroReached -= OnValueZeroReached;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
            _playerTarget.Decrease(damage);
    }

    public void OnValueZeroReached(int health)
    {
        _animator.SetTrigger(_isDead);
        Destroy(gameObject, _dieDelay);
    }

}