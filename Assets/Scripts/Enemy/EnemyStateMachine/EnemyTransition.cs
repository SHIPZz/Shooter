using UnityEngine;

public class EnemyTransition : MonoBehaviour
{
    [field: SerializeField] public EnemyState TargetState { get; private set; }

    protected Player Target { get; private set; }

    public bool NeedTransit { get; protected set; }

    public void Init(Player target) => Target = target;

    private void OnEnable()
    {
        NeedTransit = false;
    }
}