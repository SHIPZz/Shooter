using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private State initialState;

    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
    }

    private void Update()
    {
        if (CurrentState == null)
            return;
            
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