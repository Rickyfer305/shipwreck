using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float life = 100f;
    public WeaponController weaponController;
    public HealthBar healthController;
    private GameManager gameManager;
    public int coins = 0;

    private Rigidbody2D rb2d;

    private void Start()
    {
        tag = "Player";
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        healthController.SetMaxHealth(life);
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
        healthController.SetHealth(life);
        if (life <= 0) {
            //TODO: GAME OVER
            Debug.Log("GAME OVER");
            gameManager.GameOver();
        } 
    }

    public void RecollectCoin()
    {
        coins++;
    }
}

