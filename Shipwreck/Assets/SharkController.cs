using UnityEngine;

public class SharkController : MonoBehaviour
{
    // public Transform target;    // The target object (your ship)

    private PlayerController target;
    public float speed = 10f;   // The speed at which the shark moves
    public float attackRange = 3f;  // The range at which the shark will attack
    public float attackDamage = 10f;  // The amount of damage the shark will inflict on the ship
    public float life = 20f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float nextAttackTime = 0f;
    public float reloadAttackTime = 10f;
    public GameObject coin;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the shark object
        tag = "Shark";
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
        // Debug.Log("Shark is attacking the ship!");
        nextAttackTime = Time.time + reloadAttackTime;
        target.TakeDamage(attackDamage);
    }

    // This method is called when the shark collides with the ship
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {
            // Deal damage to the ship
            //other.GetComponent<ShipHealth>().TakeDamage(attackDamage);
            target.TakeDamage(attackDamage);
            // TODO: Implement the attack behavior here, e.g. play an attack animation, deal damage to the ship, etc.
            Debug.Log("Shark is attacking the ship!");
        }
        // else if (other.tag == "Bullet") {
        //     life -= 5f;
        //     Debug.Log("Shark has been hit");
        // }
    }

    public void TakeDamage(float attackDamage)
    {
        life -= attackDamage;
        Debug.Log("Shark shot: " + attackDamage.ToString());
        if (life <= 0) {
            //Shark is dead and disappears
            Destroy(gameObject);
            Instantiate(coin, transform.position, Quaternion.identity);
            Debug.Log("Shark has been destroyed");
        }
    }
}
