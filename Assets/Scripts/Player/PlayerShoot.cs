using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            weapon.TryShoot();
        }
    }
}
