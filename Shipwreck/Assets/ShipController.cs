using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    public float life = 100f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tag = "Ship";
        transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);

    }

    void FixedUpdate()
    {
        // Move the ship based on input and speed
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = moveInput.normalized * speed;

        // Rotate the ship to face the direction of movement
        if (rb.velocity.magnitude > 0.01f)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }

        // Aim and shoot using mouse input
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector3 shootDirection = (mousePosition - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection * bulletSpeed;
        }
    }

    public void TakeDamage(float attackDamage)
    {
        life -= attackDamage;
        if (life <= 0) {
            //TODO: Ship is dead and the game is over
        }
    }
}
