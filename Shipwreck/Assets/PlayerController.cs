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

    public float turnSpeed = 10f;
    public float drag = 1f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        tag = "Player";
        rb2d = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        if (healthController != null)
        {
            healthController.SetMaxHealth(life);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.velocity *= (1 - Time.deltaTime * drag);
        rb2d.velocity += movement * speed * Time.deltaTime;

        if (movement.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            targetAngle += 90f; // 90-degree offset to face forward
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime * turnSpeed);
            transform.eulerAngles = new Vector3(0, 0, currentAngle);
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector2 direction = mousePosition - transform.position;
            weaponController.Fire(direction);
        }
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        if (healthController != null)
        {
            healthController.SetHealth(life);
        }
        if (life <= 0)
        {
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
