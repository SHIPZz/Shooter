using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    private float _timer;
    private List<Transform> _wayPoints = new();
    private NavMeshAgent _agent;
    private Transform _player;
    private float _chaseRange = 8;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject gameObj = GameObject.FindGameObjectWithTag("WayPoint");
        _agent = animator.GetComponent<NavMeshAgent>();
        _timer = 0;
        _agent.speed = 1.5f;

        foreach (Transform transform in gameObj.transform)
            _wayPoints.Add(transform);

        _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_wayPoints[Random.Range(0, _wayPoints.Count)].position);

        _timer += Time.deltaTime;

        if (_timer > 2)
            animator.SetBool("IsPatrolling", false);

        float distance = Vector3.Distance(_player.position, animator.transform.position);

        if (distance < _chaseRange)
            animator.SetBool("IsChasing", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}