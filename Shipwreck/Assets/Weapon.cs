using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate;
    public float damage;
    public Sprite sprite;

    public virtual void Fire() {
        // Code for shooting the weapon
    }


}