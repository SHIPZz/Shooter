using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private State _initialState;

    private State _currentState;

    private void Start()
    {
        Transit(_initialState);
    }

    private void Update()
    {
        if (_currentState.NeedTransit)
            Transit(_currentState.NeededState);           
    }

    public void Reset(State initialState)
    {
        _currentState = initialState;
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}