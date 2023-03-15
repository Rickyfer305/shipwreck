using UnityEngine;

public class PirateController : MonoBehaviour
{
    // public Transform target;    // The target object (your ship)

    public PlayerController target;
    public float speed = 1f;   // The speed at which the shark moves
    public float attackRange = 10f;  // The range at which the shark will attack
    public float attackDamage = 10f;  // The amount of damage the shark will inflict on the ship
    public float life = 50f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject coin;

    private bool isAttacking = false;  // Flag to indicate whether the shark is currently attacking

    private void Start()
    {
        // Get the Rigidbody2D component attached to the shark object
        tag = "Pirate";
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (target != null && !isAttacking)
        {
            // Calculate the distance between the shark and the target
            float distance = Vector2.Distance(transform.position, target.transform.position);

            // If the target is within attack range, start attacking
            if (distance <= attackRange)
            {
                isAttacking = true;
                Attack();
                isAttacking = false;
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
        Debug.Log("Pirates are attacking the ship!");
    }

    // This method is called when the shark collides with the ship
    private void OnTriggerEnter(Collider other)
    {
        //TODO: Collided with something
    }

    public void TakeDamage(float attackDamage)
    {
        life -= attackDamage;
        if (life <= 0) {
            //Pirate Ship is dead and disappears
            //Leaves a coin where it was
            // Spawn a coin
            Instantiate(coin, transform.position, Quaternion.identity);

            Destroy(gameObject);
            Debug.Log("Pirate has been destroyed");
        }
    }
}
