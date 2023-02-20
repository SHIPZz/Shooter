using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    private const float Speed = 1f;
    private const float TimeToStartPatrole = 2;
    private const float ChaseRange = 8;

    private readonly int _isPatrolling = Animator.StringToHash("IsPatrolling");
    private readonly int _isChasing = Animator.StringToHash("IsChasing");

    private float _timer;
    private List<Transform> _wayPoints = new();
    private NavMeshAgent _agent;
    private Transform _player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject gameObj = GameObject.FindGameObjectWithTag("WayPoint");
        _agent = animator.GetComponent<NavMeshAgent>();
        _timer = 0;
        _agent.speed = Speed;

        foreach (Transform transform in gameObj.transform)
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

        float distance = Vector3.Distance(_player.position, animator.transform.position);

        if (distance < ChaseRange)
            animator.SetBool(_isChasing, true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}