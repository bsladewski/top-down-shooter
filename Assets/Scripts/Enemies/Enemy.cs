using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static readonly float INTERPOLATE_SPEED = 2f;

    [field: SerializeField]
    public EnemySO enemySO { get; private set; }

    [SerializeField]
    private Animator animator;

    private float attackCooldown;

    private Vector3 direction;

    private GameObject target;

    private void Update()
    {
        // enemies can't move during their attack cooldown
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            animator.SetFloat("Speed", 0f);
            return;
        }

        // determine enemy target
        if (target == null)
        {
            // TODO: target should be chosen by allies in range rather than the player character
            target = GameObject.FindGameObjectWithTag("Player");
            if (target == null)
            {
                animator.SetFloat("Speed", 0f);
                return;
            }
        }

        // handle enemy action
        if (Vector3.Distance(transform.position, target.transform.position) > enemySO.attackRange)
        {
            // if the enemy is too far to attack their target, move them towards their target
            Vector3 targetDirection = (target.transform.position - transform.position).normalized;
            direction = Vector3.Slerp(direction, targetDirection, Time.deltaTime * INTERPOLATE_SPEED);
            if (direction != Vector3.zero)
            {
                transform.LookAt(transform.position + direction);
            }

            animator.SetFloat("Speed", 1f);
            transform.position = transform.position + (direction * enemySO.moveSpeed * Time.deltaTime);
        }
        else if (attackCooldown <= 0)
        {
            // if the enemy is close to their target, attack
            animator.SetFloat("Speed", 0f);
            animator.SetTrigger("Attack");
            attackCooldown = enemySO.attackCooldown;
        }
    }
}
