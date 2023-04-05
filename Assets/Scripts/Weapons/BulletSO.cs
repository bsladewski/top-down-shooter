using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Bullet")]
public class BulletSO : ScriptableObject
{
    [field: SerializeField]
    public Transform bulletPrefab { get; private set; }

    [field: SerializeField]
    public float range { get; private set; } = 10f;

    [field: SerializeField]
    public float speed { get; private set; } = 10;
}
