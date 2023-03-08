using UnityEngine;

public class SharkController : MonoBehaviour
{
    // public Transform target;    // The target object (your ship)

    public PlayerController target;
    public float speed = 10f;   // The speed at which the shark moves
    public float attackRange = 10f;  // The range at which the shark will attack
    public float attackDamage = 10f;  // The amount of damage the shark will inflict on the ship
    private float life = 20f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isAttacking = false;  // Flag to indicate whether the shark is currently attacking

    private void Start()
    {
        // Get the Rigidbody2D component attached to the shark object
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
            }
            else
            {
                Vector3 direction = target.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle + 180;
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
        Debug.Log("Shark is attacking the ship!");
    }

    // This method is called when the shark collides with the ship
    private void OnTriggerEnter(Collider other)
    {
        if (isAttacking && other.tag == "Ship")
        {
            // Deal damage to the ship
            //other.GetComponent<ShipHealth>().TakeDamage(attackDamage);
            target.TakeDamage(attackDamage);
            // TODO: Implement the attack behavior here, e.g. play an attack animation, deal damage to the ship, etc.
            Debug.Log("Shark is attacking the ship!");
        }
    }

    public void TakeDamage(float attackDamage)
    {
        life -= attackDamage;
        if (life <= 0) {
            //TODO: Shark is dead and disappears
        }
    }
}
