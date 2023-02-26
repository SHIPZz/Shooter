using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Health _enemy;

    private void OnEnable()
    {
        _enemy.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _enemy.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int health)
    {
        _healthbar.value = health;
    }
}