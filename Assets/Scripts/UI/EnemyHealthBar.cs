using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private Health _enemy;

    private void Update()
    {
        _healthbar.value = _enemy.Wellness;
    }
}