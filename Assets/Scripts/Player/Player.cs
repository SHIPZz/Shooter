using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const int MinHealth = 0;
    private const int MaxHealth = 100;

    [SerializeField] private int _health;

    public event Action<int> HealthChanged;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, MinHealth, MaxHealth);

        if (_health <= 0)
        {
            HealthChanged?.Invoke(_health);
            Destroy(gameObject);
        }
    }
}