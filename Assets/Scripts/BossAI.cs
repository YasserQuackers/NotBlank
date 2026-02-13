using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Ensures the GameObject has an AudioSource
public class BossAI : MonoBehaviour
{
    public Transform player;
    public GameObject shadowBallPrefab;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float wanderRadius = 6f;
    public float changeTargetDistance = 0.5f;

    [Header("Combat Settings")]
    public float attackCooldown = 4f;

    [Header("Audio Settings")]
    public AudioClip throwSound; // Drag your audio clip here in the Inspector
    [Range(0f, 1f)] public float volume = 0.7f;

    private Vector3 targetPosition;
    private float nextAttackTime;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetNewPositionAroundPlayer();
    }

    void Update()
    {
        if (player == null) return;

        // Move toward chosen position
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // If reached target, pick a new one
        if (Vector3.Distance(transform.position, targetPosition) < changeTargetDistance)
        {
            SetNewPositionAroundPlayer();
        }

        // Shooting logic
        if (Time.time >= nextAttackTime)
        {
            ShootShadowBall();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void SetNewPositionAroundPlayer()
    {
        Vector2 randomCircle = Random.insideUnitCircle * wanderRadius;

        targetPosition = new Vector3(
            player.position.x + randomCircle.x,
            transform.position.y,
            player.position.z + randomCircle.y
        );
    }

    void ShootShadowBall()
    {
        // --- Play Sound ---
        if (audioSource != null && throwSound != null)
        {
            // PlayOneShot is best for SFX because it allows sounds to overlap 
            // without cutting the previous one off.
            audioSource.PlayOneShot(throwSound, volume);
        }

        GameObject ball = Instantiate(
            shadowBallPrefab,
            transform.position,
            Quaternion.identity
        );

        ShadowBall sb = ball.GetComponent<ShadowBall>();

        if (sb != null)
        {
            sb.target = player;
        }
    }
}