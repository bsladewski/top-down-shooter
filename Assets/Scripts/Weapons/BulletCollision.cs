using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Bullet, Vector3> bulletCollisionEvent;

    public void OnBulletCollision(Bullet bullet, Vector3 hitPoint)
    {
        if (bulletCollisionEvent != null)
        {
            bulletCollisionEvent.Invoke(bullet, hitPoint);
        }
    }
}
