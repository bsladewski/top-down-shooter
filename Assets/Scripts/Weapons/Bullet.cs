using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour
{
    [field: SerializeField]
    public BulletSO bulletSO { get; private set; }

    [SerializeField]
    private VisualEffect hitVFX;

    [SerializeField]
    private AudioClip[] hitSFX;

    private float durationTimer;

    private Vector3 lastPosition;

    private bool skipUpdate;

    public void SetInitialRaycastPosition(Vector3 initialRaycastPosition)
    {
        lastPosition = initialRaycastPosition;
    }

    private void Awake()
    {
        lastPosition = transform.position;
    }

    private void Start()
    {
        durationTimer = bulletSO.range / bulletSO.speed;
    }

    private void Update()
    {
        if (skipUpdate)
        {
            return;
        }

        transform.position += transform.forward * bulletSO.speed * Time.deltaTime;
        if (transform.position != lastPosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(
                lastPosition,
                (transform.position - lastPosition).normalized,
                Vector3.Distance(lastPosition, transform.position));
            HandleBulletCollisions(hits);
        }

        durationTimer -= Time.deltaTime;
        if (durationTimer <= 0f)
        {
            DestroySelf();
            return;
        }
        lastPosition = transform.position;
    }

    private void HandleBulletCollisions(RaycastHit[] hits)
    {
        foreach (RaycastHit hit in hits)
        {
            BulletCollision bulletCollision = hit.transform.gameObject.GetComponent<BulletCollision>();
            if (bulletCollision != null)
            {
                // position the bullet slightly in front of the hit point
                transform.position = hit.point - transform.forward * 0.05f;
                transform.forward = hit.normal;

                bulletCollision.OnBulletCollision(this, hit.point);
                hitVFX.Play();
                if (hitSFX != null && hitSFX.Length > 0)
                {
                    SoundSystem.Instance.Play(hitSFX[Random.Range(0, hitSFX.Length)], transform.position);
                }
                DestroySelf();
                return;
            }
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject, 0.5f);
        skipUpdate = true;
    }
}
