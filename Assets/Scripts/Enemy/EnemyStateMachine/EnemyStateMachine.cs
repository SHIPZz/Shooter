using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _initialState;
    [SerializeField] private Player _target;

    private EnemyState _currentState;

    private void Start()
    {
        Reset(_initialState);
    }

    private void Update()
    {
        if (_currentState is null)
            return;

        var nextState = _currentState.GetNext();

        if (nextState is not null)
            Transit(nextState);
    }

    private void Reset(EnemyState initalState)
    {
        _currentState = initalState;

        if (_currentState is not null)
            _currentState.Enter(_target);
    }

    private void Transit(EnemyState nextState)
    {
        if (_currentState is not null)
            _currentState.Exit();
    }
}