using System.Collections;
using UnityEngine;

public class SharkGenerator : MonoBehaviour {

    public GameObject enemy;
    private PlayerController player;
    public float xPos;
    public float yPos;
    public int sharkCount;
    public float spawnTime = 5f;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop() {
        while (true) 
        {
            //x = -13, 13
            //y = -6, 6
            // Generate random enemies out of the bounds
            if (Random.value > 0.5) 
            {
                xPos = Random.Range(-15, 15);
                if (Random.value > 0.5) { yPos = -8f; }
                else { yPos = 8f; }
            }
            else 
            {
                if (Random.value > 0.5) { xPos = -15f; }
                else { xPos = 15f; }
                yPos = Random.Range(-8, 8);
            }
            xPos += player.transform.position.x;
            yPos += player.transform.position.y;
            Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            // Debug.Log("Shark spawned at: (" + xPos + "," + yPos + ")");
            yield return new WaitForSeconds(spawnTime);
            sharkCount += 1;
        }
    }
}