using UnityEngine;

public class Bullet : MonoBehaviour
{
    // The speed at which this bullet moves
    public float speed = 10f;

    // The amount of damage this bullet does
    public float damage = 1f;

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward based on its speed and the elapsed time
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
        Debug.Log("Bullet position: " + transform.position);
    }

    // Handle collisions with other objects
    void OnTriggerEnter(Collider other)
    {
        // // Check if the other object has a Health component
        // Health health = other.GetComponent<Health>();
        // if (health != null)
        // {
        //     // Deal damage to the other object's health
        //     health.TakeDamage(damage);
        // }

        // Destroy the bullet object
        Destroy(gameObject);
    }
}
