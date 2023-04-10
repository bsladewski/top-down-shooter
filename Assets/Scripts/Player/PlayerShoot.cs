using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private Animator animator;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            if (weapon.TryShoot())
            {
                animator.SetTrigger("Shoot");
            }
        }
    }
}
