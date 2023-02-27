using UnityEngine;

public class CannonController : MonoBehaviour
{
    private void Update()
    {
        // Get the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the angle between the cannon and the mouse
        Vector2 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the cannon's rotation to the calculated angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
    }
}