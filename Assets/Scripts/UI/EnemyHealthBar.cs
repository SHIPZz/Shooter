using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        _healthbar.value = _enemy.Health.Wellness;
    }
}