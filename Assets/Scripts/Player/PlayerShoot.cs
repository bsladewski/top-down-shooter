using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private Animator animator;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (weapon.TryShoot())
            {
                animator.SetTrigger("Shoot");
            }
        }
    }
}
