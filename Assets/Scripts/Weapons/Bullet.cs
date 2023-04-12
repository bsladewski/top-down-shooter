using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField]
    public BulletSO bulletSO { get; private set; }

    private float durationTimer;

    private Vector3 lastPosition;

    private void Start()
    {
        durationTimer = bulletSO.range / bulletSO.speed;
        lastPosition = transform.position;
    }

    private void Update()
    {
        transform.position += transform.forward * bulletSO.speed * Time.deltaTime;
        if (transform.position != lastPosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(
                lastPosition,
                (transform.position - lastPosition).normalized,
                Vector3.Distance(lastPosition, transform.position));
            foreach (RaycastHit hit in hits)
            {
                BulletCollision bulletCollision = hit.transform.gameObject.GetComponent<BulletCollision>();
                if (bulletCollision != null) HandleBulletCollision(bulletCollision, hit.point);
            }
        }

        durationTimer -= Time.deltaTime;
        if (durationTimer <= 0f)
        {
            Destroy(gameObject);
        }
        lastPosition = transform.position;
    }

    private void HandleBulletCollision(BulletCollision bulletCollision, Vector3 hitPoint)
    {
        bulletCollision.OnBulletCollision(this, hitPoint);
    }
}
