using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    private const float zPos = -20;


    private void Start() {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
    }

}