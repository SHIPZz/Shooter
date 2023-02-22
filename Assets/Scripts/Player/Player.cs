using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : MonoBehaviour
{
    private readonly float _dieDelay = 5f;
    private Animator _animator;

    public Health Health { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Health = GetComponent<Health>();
    }

    public void OnZeroHealthReached(int health)
    {
        Destroy(gameObject, _dieDelay);
    }

    private void OnEnable()
    {
        Health.OnWellnessZeroReached += OnZeroHealthReached;
    }

    private void OnDisable()
    {
        Health.OnWellnessZeroReached -= OnZeroHealthReached;
    }
}