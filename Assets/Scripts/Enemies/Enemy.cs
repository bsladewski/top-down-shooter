using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField]
    public EnemySO enemySO { get; private set; }

    [SerializeField]
    private Animator animator;

    private float attackCooldown;

    private GameObject target;

    private void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            return;
        }

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            if (target == null)
            {
                return;
            }
        }

        if (Vector3.Distance(transform.position, target.transform.position) > enemySO.attackRange)
        {
            transform.LookAt(target.transform.position);
            Vector3 targetPosition = (target.transform.position - transform.position).normalized;
            transform.position = transform.position + (targetPosition * enemySO.moveSpeed * Time.deltaTime);
            animator.SetBool("Moving", true);
        }
        else if (attackCooldown <= 0)
        {
            animator.SetBool("Moving", false);
            animator.SetTrigger("Attack");
            attackCooldown = enemySO.attackCooldown;
        }
    }
}
