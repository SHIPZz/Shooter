using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Health _enemy;

    private void OnEnable()
    {
        _enemy.WellnessChanged += OnWellnessChanged;
    }

    private void OnDisable()
    {
        _enemy.WellnessChanged -= OnWellnessChanged;
    }

    private void OnWellnessChanged(int health)
    {
        _healthbar.value = health;
    }
}