using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    private const float Speed = 1f;
    private const float TimeToStartPatrole = 2;
    private const float ChaseRange = 8;

    [SerializeField] private GameObject _wayPoint;

    private static readonly int _isPatrolling = Animator.StringToHash("IsPatrolling");
    private static readonly int _isChasing = Animator.StringToHash("IsChasing");

    private Player _player;
    private float _timer;
    private List<Transform> _wayPoints = new();
    private NavMeshAgent _agent;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _timer = 0;
        _agent.speed = Speed;

        foreach (Transform transform in _wayPoint.transform)
            _wayPoints.Add(transform);

        _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);

        _timer += Time.deltaTime;

        if (_timer > TimeToStartPatrole)
            animator.SetBool(_isPatrolling, false);

        float distance = Vector3.Distance(_player.transform.position, animator.transform.position);

        if (distance < ChaseRange)
            animator.SetBool(_isChasing, true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}