using UnityEngine;
using UnityEngine.VFX;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponSO weaponSO;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private VisualEffect muzzleFlareVFX;

    [SerializeField]
    private AudioClip[] shootSFX;

    [SerializeField, Tooltip("Adjusts the initial bullet raycast position to account for bullet spawn point clipping.")]
    private float bulletSpawnRaycastOffset;

    private float cooldown;

    private void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public bool TryShoot()
    {
        if (cooldown <= 0f)
        {
            cooldown = 1f / weaponSO.shotsPerSecond;
            for (int i = 0; i < weaponSO.projectilesPerShot; i++)
            {
                Vector3 bulletLookAt = bulletSpawn.position + bulletSpawn.forward;
                bulletLookAt.y = bulletSpawn.position.y;
                Transform bullet = Instantiate(
                    weaponSO.bulletSO.bulletPrefab,
                    bulletSpawn.position,
                    Quaternion.identity);
                bullet.transform.LookAt(bulletLookAt, Vector3.up);
                bullet.transform.Rotate(
                    0f,
                    Random.Range(-weaponSO.spread, weaponSO.spread),
                    0f
                );
                bullet.GetComponent<Bullet>().SetInitialRaycastPosition(
                    bulletSpawn.position - bulletSpawn.forward * bulletSpawnRaycastOffset);
            }
            muzzleFlareVFX.Play();
            SoundSystem.Instance.Play(shootSFX[Random.Range(0, shootSFX.Length)], transform.position);
            return true;
        }
        return false;
    }
}
