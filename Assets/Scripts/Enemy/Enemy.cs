using System;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    public event Action<int> OnHealthChanged;
    private Animator _animator;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (_health.Wellness == 0)
        //{
        //    Destroy(gameObject);
        //}

        //OnHealthChanged?.Invoke(_health.Wellness);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);

        if (_health.Wellness == 0)
        {
            _animator.SetTrigger("IsDead");
            //Destroy(gameObject);
        }

        OnHealthChanged?.Invoke(_health.Wellness);
    }
}