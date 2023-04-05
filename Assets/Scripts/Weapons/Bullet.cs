using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private BulletSO bulletSO;

    private float durationTimer;

    private void Start()
    {
        durationTimer = bulletSO.range / bulletSO.speed;
    }

    private void Update()
    {
        transform.position += transform.forward * bulletSO.speed * Time.deltaTime;
        durationTimer -= Time.deltaTime;
        if (durationTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
