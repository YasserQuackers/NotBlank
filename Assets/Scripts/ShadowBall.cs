using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;
    public float lifeTime = 6f;
    public PlayerHealth playerHealth;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(20);
            }

            Destroy(gameObject);
        }
    }
}
