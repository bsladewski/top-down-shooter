using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon")]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField]
    public BulletSO bulletSO { get; private set; }

    [field: SerializeField]
    public float shotsPerSecond { get; private set; } = 5f;

    [field: SerializeField]
    public int projectilesPerShot { get; private set; } = 1;

    [field: SerializeField]
    public float spread { get; private set; } = 10f;
}
