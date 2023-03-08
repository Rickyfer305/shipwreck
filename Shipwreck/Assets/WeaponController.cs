
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // The weapon(s) the player has
    public Weapon[] weapons;

    // The index of the currently selected weapon
    public int selectedWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set the currently selected weapon
        SelectWeapon(selectedWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for weapon selection input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }
        // Add more key codes for additional weapons as desired

        // Check for fire input
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    // Select a weapon by index
    void SelectWeapon(int index)
    {
        // Disable all weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }

        // Enable the selected weapon
        weapons[index].gameObject.SetActive(true);

        // Set the selected weapon index
        selectedWeaponIndex = index;
    }

    // Fire the currently selected weapon
    public void Fire()
    {
        // Call the Fire() method of the selected weapon
        weapons[selectedWeaponIndex].Fire();
    }
}


