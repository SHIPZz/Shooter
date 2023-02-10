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

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);

        if (_health.Wellness <= 0)
        {
            HealthChanged?.Invoke(_health.Wellness);
            Destroy(gameObject);
        }
    }
}