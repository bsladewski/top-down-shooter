using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private Animator animator;

    private PlayerCombatInputActions inputActions;

    private void Start()
    {
        inputActions = new PlayerCombatInputActions();
        inputActions.Enable();
    }

    private void Update()
    {
        if (inputActions.Default.Shoot.IsPressed() && weapon.TryShoot())
        {
            animator.SetTrigger("Shoot");
        }
    }
}
