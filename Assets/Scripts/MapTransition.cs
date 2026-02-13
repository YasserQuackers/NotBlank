using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private PolygonCollider2D mapBoundary;

    private CinemachineConfiner2D _confiner;

    private void Awake()
    {
        _confiner = Object.FindFirstObjectByType<CinemachineConfiner2D>();

        // Safety check to avoid NullReferenceExceptions
        if (_confiner == null)
        {
            Debug.LogWarning($"No CinemachineConfiner2D found in the scene for {gameObject.name}");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _confiner != null)
        {
            _confiner.BoundingShape2D = mapBoundary;

            // Crucial: Tells Cinemachine to clear the old boundary math
            _confiner.InvalidateCache();
        }
    }
}