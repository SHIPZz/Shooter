using UnityEngine;

public class MoveState : EnemyState
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Target == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}