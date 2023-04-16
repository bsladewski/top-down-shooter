using UnityEngine;
using UnityEngine.Events;

public class BulletCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent bulletCollisionEvent;

    public void OnBulletCollision(Bullet bullet, Vector3 hitPoint)
    {
        if (bulletCollisionEvent != null) bulletCollisionEvent.Invoke();
    }
}
