using UnityEngine;

public class PirateController : MonoBehaviour
{
    // public Transform target;    // The target object (your ship)

    private PlayerController target;
    public float speed = 1f;   // The speed at which the shark moves
    public float attackRange = 10f;  // The range at which the shark will attack
    public float attackDamage = 10f;  // The amount of damage the shark will inflict on the ship
    public float life = 50f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float nextAttackTime = 0f;
    public float reloadAttackTime = 15f;
    public GameObject coin;
    public GameObject bulletPrefab;
    public float bulletSpeed = 15f;
    public GameObject explosion;
    private void Start()
    {
        // Get the Rigidbody2D component attached to the shark object
        tag = "Pirate";
        target = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the distance between the shark and the target
            float distance = Vector2.Distance(transform.position, target.transform.position);

            // If the target is within attack range, start attacking
            if (distance <= attackRange && nextAttackTime < Time.time)
            {
                Debug.Log("Pirates attacking");
                Attack();
            }
            else
            {
                Vector3 direction = target.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle + 90;
                direction.Normalize();
                movement = direction;
                moveCharacter(movement);
            }
        }
    }

    private void moveCharacter(Vector2 direction) 
    {
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    private void Attack()
    {
        // TODO: Implement the attack behavior here, e.g. play an attack animation, deal damage to the ship, etc.
        // Debug.Log("Pirates are attacking the ship!");
        nextAttackTime = Time.time + reloadAttackTime;

        //Throw a bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Set the bullet's speed and damage based on the weapon's properties
        Vector2 playerPosition = (Vector2)target.transform.position;
        Vector2 fireDirection = (playerPosition - (Vector2)transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = fireDirection * bulletSpeed;
        Debug.Log("Bullet shot from pirates");
    }

    // This method is called when the shark collides with the ship
    private void OnTriggerEnter(Collider other)
    {
        //TODO: Collided with something
        Debug.Log("Pirate collided with " + other.tag);
    }

    public void TakeDamage(float attackDamage)
    {
        life -= attackDamage;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("Pirate shot: " + attackDamage.ToString());
        if (life <= 0) {
            //Pirate Ship is dead and disappears
            Destroy(gameObject);
            Instantiate(coin, transform.position, Quaternion.identity);
            Debug.Log("Pirate has been destroyed");
        }
    }
}
