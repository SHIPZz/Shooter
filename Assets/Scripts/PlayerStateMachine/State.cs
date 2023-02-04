using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
   [SerializeField] private List<Transition> _transitions = new List<Transition>();

    public bool NeedTransit { get; private set; }
    public State NeededState { get; private set; }


    private void Update()
    {

    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public void Enter()
    {
        if (enabled is false)
        {
            enabled = true;

            foreach (Transition transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }
}