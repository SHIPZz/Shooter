using System;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private readonly float _dieDelay = 10f;

    public event Action<int> OnHealthChanged;
    private Animator _animator;

    public Health Health { get; private set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health.Decrease(damage);

        if (Health.Wellness == 0)
        {
            _animator.SetTrigger("IsDead");
            Destroy(gameObject, _dieDelay);
        }

        OnHealthChanged?.Invoke(Health.Wellness);
    }
}