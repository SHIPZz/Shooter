using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    public event Action<int> OnHealthChanged;

    private void Awake()
    {
        _health = GetComponent<Health>();
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
            Destroy(gameObject);
        }

        OnHealthChanged?.Invoke(_health.Wellness);
    }
}
