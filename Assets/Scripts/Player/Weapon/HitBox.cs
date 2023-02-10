using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void OnRaycastHit(int damage, Vector3 direction)
    {
        _enemy.TakeDamage(damage, direction);
    }

    private void OnEnable()
    {
        _enemy.OnHealthChanged += OnRaycastHit;
    }

    private void OnDisable()
    {
        _enemy.OnHealthChanged -= OnRaycastHit;
    }

}
