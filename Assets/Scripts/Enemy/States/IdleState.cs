using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private static readonly int _isChasing = Animator.StringToHash("IsChasing");
    private static readonly int _isPatrolling = Animator.StringToHash("IsPatrolling");
    private readonly float _timeToPatrole = 5;

    private Player _player;
    private float _timer;
    private float _chaseRange = 8;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if (_timer > _timeToPatrole)
            animator.SetBool(_isPatrolling, true);

        float distance = Vector3.Distance(_player.transform.position, animator.transform.position);

        if (distance < _chaseRange)
            animator.SetBool(_isChasing, true);
    }
}