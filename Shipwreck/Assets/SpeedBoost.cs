using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoost : MonoBehaviour
{
    public float boostCooldownTime = 10f;
    public float boostActiveTime = 5f;
    private float boostedSpeed = 10f;
    private PlayerController player;
    private KeyCode boostKey = KeyCode.Space;
    private bool isBoostOnCooldown = true;
    private bool boostIsActive = false;
    private float originalSpeed;
    public Image boostIcon;
    

    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //SpeedBoost starts to load
        StartCoroutine(BoostCoroutineLoad());
    }

    private void Update() {
        // If the player presses space and boost is ready for being used (loaded and not active)
        if (Input.GetKeyDown(KeyCode.Space) && !isBoostOnCooldown && !boostIsActive) {
            StartCoroutine(BoostCoroutineAction());
        }
    }

    //Waits for 10s and actives the boost
    IEnumerator BoostCoroutineLoad()
    {
        isBoostOnCooldown = true;
        //Show that boost is loading
        boostIcon.material.color = new Color(0,0,0);

        yield return new WaitForSeconds(boostCooldownTime);
        
        isBoostOnCooldown = false;
        //Action to show that the boost is available
        boostIcon.material.color = new Color(0,0,255);

    }

    // Activate the boost -> Set the new speed
    IEnumerator BoostCoroutineAction() {
        // Show that boost is active
        boostIcon.material.color = new Color(255,0,0);
        boostIsActive = true;
        originalSpeed = player.speed;
        player.speed = boostedSpeed;

        // Wait for the boost to end
        yield return new WaitForSeconds(boostActiveTime);

        // End boost
        player.speed = originalSpeed;
        boostIsActive = false;

        //Reload boost
        StartCoroutine(BoostCoroutineLoad());
    }


}
