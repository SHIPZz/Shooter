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

    private void OnEnable()
    {
        Health.WellnessZeroReached += OnZeroWellnessReached;
    }

    private void OnDisable()
    {
        Health.WellnessZeroReached -= OnZeroWellnessReached;
    }

    public void OnZeroWellnessReached(int health)
    {
        Destroy(gameObject, _dieDelay);
    }
}