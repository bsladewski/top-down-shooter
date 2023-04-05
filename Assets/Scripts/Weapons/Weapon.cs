using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponSO weaponSO;

    [SerializeField]
    private Transform bulletSpawn;

    private float cooldown = 0f;

    private void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TryShoot()
    {
        if (cooldown <= 0f)
        {
            cooldown = 1f / weaponSO.shotsPerSecond;
            Transform bullet = Instantiate(
                weaponSO.bulletSO.bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
            bullet.transform.Rotate(
                Random.Range(-weaponSO.spread, weaponSO.spread),
                Random.Range(-weaponSO.spread, weaponSO.spread),
                0f
            );
        }
    }
}
