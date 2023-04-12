using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent bulletCollisionEvent;

    [SerializeField]
    private AudioClip[] hitSFX;

    [SerializeField]
    private VisualEffect hitVFX;

    public void OnBulletCollision(Bullet bullet, Vector3 hitPoint)
    {
        if (hitVFX) hitVFX.Play();
        if (hitSFX != null && hitSFX.Length > 0)
        {
            SoundSystem.Instance.Play(hitSFX[Random.Range(0, hitSFX.Length)], bullet.transform.position);
        }

        if (bulletCollisionEvent != null) bulletCollisionEvent.Invoke();
        Destroy(bullet.gameObject);
    }
}
