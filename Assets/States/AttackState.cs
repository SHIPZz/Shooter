using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private readonly float _timeToOffAttack = 1;

    private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(_player);
        float distance = Vector3.Distance(_player.position, animator.transform.position);

        if (distance > _timeToOffAttack)
            animator.SetBool("IsAttacking", false);
    }
}