using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [field: SerializeField] protected State _targetState { get; private set; }

    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

}