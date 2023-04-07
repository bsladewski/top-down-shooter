using UnityEngine;
using UnityEngine.VFX;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponSO weaponSO;

    [SerializeField]
    private Transform bulletSpawn;

    [SerializeField]
    private VisualEffect muzzleFlare;

    [SerializeField]
    private AudioClip[] shootSFX;

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
            for (int i = 0; i < weaponSO.projectilesPerShot; i++)
            {
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
            muzzleFlare.Play();
            SoundSystem.Instance.Play(shootSFX[Random.Range(0, shootSFX.Length)], transform.position);
        }
    }
}
