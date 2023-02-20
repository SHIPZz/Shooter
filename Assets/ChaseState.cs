using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    private const float Speed = 3.5f;
    private const float DistanceToOffChasing = 15;
    private const float DistanceToAttack = 2;

    private readonly int _isChasing = Animator.StringToHash("IsChasing");
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private NavMeshAgent _agent;
    private Transform _player;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.speed = Speed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.position);

        float distance = Vector3.Distance(_player.position, animator.transform.position);

        if (distance > DistanceToOffChasing)
            animator.SetBool(_isChasing, false);
        if (distance < DistanceToAttack)
            animator.SetBool(_isAttacking, true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(animator.transform.position);
    }
}