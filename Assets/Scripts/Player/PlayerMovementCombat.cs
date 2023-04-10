using UnityEngine;

public class PlayerMovementCombat : MonoBehaviour
{
    private static readonly float INTERPOLATE_SPEED = 16f;
    private static readonly float MOVE_SPEED = 3f;

    [SerializeField]
    private Animator animator;

    private CharacterController characterController;

    private Vector2 moveDir;

    private Vector2 aimDir;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // get target movement direction from player input
        Vector2 targetMoveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) targetMoveDir.y += 1f;
        if (Input.GetKey(KeyCode.S)) targetMoveDir.y -= 1f;
        if (Input.GetKey(KeyCode.D)) targetMoveDir.x += 1f;
        if (Input.GetKey(KeyCode.A)) targetMoveDir.x -= 1f;
        targetMoveDir = targetMoveDir.normalized;

        // get target aim direction from player input
        Vector2 targetAimDir = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) targetAimDir.y += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) targetAimDir.y -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) targetAimDir.x += 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) targetAimDir.x -= 1f;
        if (targetAimDir == Vector2.zero) targetAimDir = targetMoveDir;

        // smooth movement direction
        moveDir = Vector2.Lerp(moveDir, targetMoveDir, Time.deltaTime * INTERPOLATE_SPEED);

        // apply player movement
        characterController.Move(new Vector3(moveDir.x, 0f, moveDir.y) * MOVE_SPEED * Time.deltaTime);

        // smooth aim direction
        aimDir = Vector2.Lerp(aimDir, targetAimDir, Time.deltaTime * INTERPOLATE_SPEED);

        // apply player aim
        if (aimDir != Vector2.zero) transform.LookAt(transform.position + new Vector3(aimDir.x, 0f, aimDir.y));

        // translate movement direction from world space to local space
        Vector3 localMoveDir = transform.InverseTransformVector(new Vector3(moveDir.x, 0f, moveDir.y));

        // update the player movement animation
        animator.SetFloat("Forward", localMoveDir.z);
        animator.SetFloat("Strafe", localMoveDir.x);
    }
}
