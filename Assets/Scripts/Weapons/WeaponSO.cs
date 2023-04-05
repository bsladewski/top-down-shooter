using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon")]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField]
    public BulletSO bulletSO { get; private set; }

    [field: SerializeField]
    public float shotsPerSecond = 5f;

    [field: SerializeField]
    public int projectilesPerShot = 1;

    [field: SerializeField]
    public float spread = 10f;
}
