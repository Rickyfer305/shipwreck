using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The speed at which this bullet moves
    public float speed = 10f;

    // The amount of damage this bullet does
    public float damage;

    private Rigidbody2D rb;

    // The direction this bullet should face when it is created
    public Vector3 facingDirection;


    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward based on its speed and the elapsed time
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rb = GetComponent<Rigidbody2D>();
        transform.position += transform.forward * speed * Time.deltaTime;
        // Debug.Log("Bullet position: " + transform.position);

    }

    // Handle collisions with other objects
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Bullet collision");
        GameObject collision = other.gameObject;
        if (other.tag == "Shark")
        {
            // Debug.Log("Shark has been shot");
            SharkController enemy = collision.GetComponent<SharkController>();
            enemy.TakeDamage(damage);

        }
        else if (other.tag == "Pirate")
        {
            // Debug.Log("Pirate has been shot");
            PirateController enemy = other.GetComponent<PirateController>();
            enemy.TakeDamage(damage);
        }
        else if (other.tag == "Player")
        {
            //Debug.Log("Player has been shot");
            PlayerController enemy = other.GetComponent<PlayerController>();
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet object
        Destroy(gameObject);
    }
}
