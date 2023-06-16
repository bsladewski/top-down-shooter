using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField]
    public Transform enemyPrefab { get; private set; }

    [field: SerializeField]
    public float moveSpeed { get; private set; } = 3;

    [field: SerializeField]
    public float attackCooldown { get; private set; } = 1f;

    [field: SerializeField]
    public float attackRange { get; private set; } = 1f;

    [field: SerializeField]
    public int health { get; private set; } = 10;
}
