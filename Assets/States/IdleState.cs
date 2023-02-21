using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private readonly int _isChasing = Animator.StringToHash("IsChasing");
    private readonly int _isPatrolling = Animator.StringToHash("IsPatrolling");
    private readonly float _timeToPatrole = 5;

    private float _timer;
    private Transform _player;
    private float _chaseRange = 8;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
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

        float distance = Vector3.Distance(_player.position, animator.transform.position);

        if (distance < _chaseRange)
            animator.SetBool(_isChasing, true);
    }
}