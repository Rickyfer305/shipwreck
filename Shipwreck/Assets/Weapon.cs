using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate;
    public Transform firePoint;
    public float damage;
    public Sprite sprite;

    public virtual void Fire(Vector2 direction) {
        // Code for shooting the weapon
    }


}