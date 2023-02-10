using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private readonly int _maxHealth = 100;
    private readonly int _minHealth = 0;

    public int Health => _health;

    public event Action<int, Vector3> OnHealthChanged;

    public void TakeDamage(int damage, Vector3 direction)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);

        if (_health == 0)
        {
            Destroy(gameObject);
            OnHealthChanged?.Invoke(_health, direction);
        }
    }
}
