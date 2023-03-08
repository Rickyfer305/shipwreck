using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float life = 100f;
    public WeaponController weaponController;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move the player using keyboard input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;
    }

    private void Update()
    {
        // Fire the weapon when the player presses the fire button
        if (Input.GetButton("Fire1"))
        {
            weaponController.Fire();
        }
    }

    public void TakeDamage(float damage) 
    {
        life -= damage;
        if (life <= 0) {
            //TODO: GAME OVER
        } 
    }
}

