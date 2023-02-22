using Unity.VisualScripting;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private readonly float _timeToOffAttack = 1;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(_player.transform);
        float distance = Vector3.Distance(_player.transform.position, animator.transform.position);

        if (distance > _timeToOffAttack)
            animator.SetBool("IsAttacking", false);
    }
}