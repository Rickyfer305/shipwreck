using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float life = 100f;
    public WeaponController weaponController;
    public HealthBar healthController;
    private GameManager gameManager;
    public int coins = 0;
    public int kills = 0;

    private Rigidbody2D rb2d;

    private void Start()
    {
        tag = "Player";
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        if (healthController != null){
            healthController.SetMaxHealth(life);
        }
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
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Get the direction from the player's position to the mouse position
            Vector2 direction = mousePosition - transform.position;
            weaponController.Fire(direction);
        }
    }

    public void TakeDamage(float damage) 
    {
        life -= damage;
        if (healthController != null){
            healthController.SetHealth(life);
        }
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

    public void AddKill()
    {
        kills++;
    }
}

