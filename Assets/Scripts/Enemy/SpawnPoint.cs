using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private CharacterAiming _player;

    private WaitForSeconds _delay = new WaitForSeconds(1.5f);
    private Coroutine _createEnemiesCoroutine;

    private void Start()
    {
        StartSpawn();
    }

    private void StartSpawn()
    {
        StopSpawn();

        _createEnemiesCoroutine = StartCoroutine(GenerateEnemies());
    }

    private void StopSpawn()
    {
        if (_createEnemiesCoroutine != null)
            StopCoroutine(_createEnemiesCoroutine);
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