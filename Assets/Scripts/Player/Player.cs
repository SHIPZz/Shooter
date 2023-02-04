using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const int MinHealth = 0;
    private const int MaxHealth = 100;

    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    private Animator _animator;

    private void Start()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health, MinHealth, MaxHealth);

        _health -= damage;

        HealthChanged?.Invoke(_health);
        
        if(_health <= 0)
            Destroy(gameObject);
    }

}