using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private CharacterAiming _player;

    private WaitForSeconds _delay = new WaitForSeconds(7f);
    private Coroutine _createEnemies;

    private void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        StopSpawn();

        _createEnemies = StartCoroutine(GenerateEnemies());
    }

    private void StopSpawn()
    {
        if (_createEnemies != null)
            StopCoroutine(_createEnemies);
    }

    private IEnumerator GenerateEnemies()
    {
        while (_player != null)
        {
            foreach (var point in _points)
            {
                Enemy newEnemy = Instantiate(_enemy, point.position, Quaternion.identity);

                yield return _delay;
            }
        }
    }
}