using System;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private readonly float _dieDelay = 10f;

    private Health _health;

    public event Action<int> OnHealthChanged;
    private Animator _animator;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);

        if (_health.Wellness == 0)
        {
            _animator.SetTrigger("IsDead");
            Destroy(gameObject, _dieDelay);
        }

        OnHealthChanged?.Invoke(_health.Wellness);
    }
}