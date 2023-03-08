using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float lifetime = 2f; // Lifetime of the bullet in seconds
    public int damage = 1; // Damage the bullet will deal to enemies

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet
        rb.velocity = transform.up * speed;

        // Destroy the bullet after its lifetime has expired
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet has hit an enemy
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            // TODO: Implement the attack behavior here
            //other.GetComponent<EnemyController>().TakeDamage(damage);
            Debug.Log("Ship is being attacked!");
            // Destroy the bullet on impact
            Destroy(gameObject);
        }
    }
}
