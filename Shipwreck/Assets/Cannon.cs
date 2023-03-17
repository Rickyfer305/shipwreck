using UnityEngine;

public class Cannon : Weapon
{
    private void Start(){
        // The amount of damage this weapon does
        damage = 10f;

        // The time between shots when firing this weapon
        fireRate = 0.5f;
    }    

    // The speed at which bullets from this weapon move
    public float bulletSpeed = 20f;

    // The prefab to use for bullets fired from this weapon
    public GameObject bulletPrefab;

    // The time until the next shot can be fired
    private float nextFireTime = 0f;

    private void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the fire point to the mouse position
        Vector2 direction = (mousePosition - firePoint.position).normalized;

        // Calculate the angle between the fire point's current up direction and the direction to the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the calculated rotation to the weapon
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    // Fire the weapon
    public override void Fire(Vector2 direction)
    {
        // Check if enough time has passed since the last shot
        if (Time.time > nextFireTime)
        {
            // Instantiate a new bullet prefab at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set the bullet's speed and damage based on the weapon's properties
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 fireDirection = (mousePosition - (Vector2)firePoint.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = fireDirection * bulletSpeed;


            // bullet.GetComponent<Bullet>().damage = damage;

            // Set the next available time for firing
            nextFireTime = Time.time + fireRate;
        }
    }
}
