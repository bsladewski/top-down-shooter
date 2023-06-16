using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private BulletCollision bulletCollision;

    private Vector3 startPosition;

    private bool isDying;

    private float sinkCooldown = 5f;

    private float sinkSpeed = 0.25f;

    private void Start()
    {
        bulletCollision = GetComponent<BulletCollision>();
    }

    private void Update()
    {
        if (!isDying)
        {
            return;
        }

        if (sinkCooldown > 0)
        {
            sinkCooldown -= Time.deltaTime;
            return;
        }

        if (Vector3.Distance(startPosition, transform.position) < 2f)
        {
            transform.position = transform.position + Vector3.down * sinkSpeed * Time.deltaTime;
            return;
        }

        Destroy(gameObject);
    }

    public void Die()
    {
        Destroy(bulletCollision);
        animator.SetTrigger("Die");
        isDying = true;
        startPosition = transform.position;
    }
}
