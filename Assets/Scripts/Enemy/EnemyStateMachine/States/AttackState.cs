using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : EnemyState
{
    [SerializeField] private int _damage;
    [SerializeField] private int _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Z_Attack");
        target.TakeDamage(_damage);
    }
}