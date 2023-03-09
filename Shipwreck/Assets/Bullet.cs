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
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Handle collisions with other objects
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Shark") {
            SharkController enemy = other.GetComponent<SharkController>();
            enemy.TakeDamage(damage);

        }
        else if (other.tag == "Pirate") {
            PirateController enemy = other.GetComponent<PirateController>();
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet object
        Destroy(gameObject);
    }
}
