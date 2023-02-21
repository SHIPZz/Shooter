using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    private const float Speed = 3.5f;
    private const float DistanceToOffChasing = 15;
    private const float DistanceToAttack = 1;

    private static readonly int _isChasing = Animator.StringToHash("IsChasing");
    private static readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private Player _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = Speed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.transform.position);

        float distance = Vector3.Distance(_player.transform.position, animator.transform.position);

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