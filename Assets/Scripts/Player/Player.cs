using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : MonoBehaviour
{
    public event Action<int> HealthChanged;

    private Animator _animator;
    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.Wellness <= 0)
        {
            Destroy(gameObject);
        }

        HealthChanged?.Invoke(_health.Wellness);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);

        HealthChanged?.Invoke(damage);
    }
}