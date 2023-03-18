using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    private const float zPos = -20;

    Rect viewport = new Rect(0f, 0f, 1f, 1f);

    private void Start() {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = Mathf.Max(5f, (viewport.width / 2f) / screenAspect);       
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
    }
}
