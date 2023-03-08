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

    // The position where bullets should spawn when fired from this weapon
    public Transform firePoint;

    // The time until the next shot can be fired
    private float nextFireTime = 0f;

    // Fire the weapon
    public override void Fire()
    {
        // Check if enough time has passed since the last shot
        if (Time.time > nextFireTime)
        {
            // Instantiate a new bullet prefab at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set the bullet's speed and damage based on the weapon's properties
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.speed = bulletSpeed;
            bulletComponent.damage = damage;

            // Set the next available time for firing
            nextFireTime = Time.time + fireRate;
        }
    }
}
