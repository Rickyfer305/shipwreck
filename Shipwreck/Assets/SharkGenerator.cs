using System.Collections;
using UnityEngine;

public class SharkGenerator : MonoBehaviour {

    public GameObject enemy;
    public int xPos;
    public int yPos;
    public int sharkCount;
    public float spawnTime = 5f;

    private void Start() {
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
                if (Random.value > 0.5) { yPos = -8; }
                else { yPos = 8; }
            }
            else 
            {
                if (Random.value > 0.5) { xPos = -15; }
                else { xPos = 15; }
                yPos = Random.Range(-8, 8);
            }
            Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
            Debug.Log("Spawned at: (" + xPos + "," + yPos + ")");
            yield return new WaitForSeconds(spawnTime);
            sharkCount += 1;
        }
    }
}