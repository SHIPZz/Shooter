using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : MonoBehaviour
{
    private readonly float _dieDelay = 5f;
    private Animator _animator;

    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueZeroReached += OnZeroValueReached;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= OnZeroValueReached;
    }

    public void OnZeroValueReached(int health)
    {
        Destroy(gameObject, _dieDelay);
    }
}