using UnityEngine;


public class SpeedButton : MonoBehaviour {
    public Transform myCamera;
    public float xCoordinate, yCoordinate, zCoordinate;
    
    void Update()
    {
        transform.position = myCamera.position + new Vector3 (xCoordinate, yCoordinate, zCoordinate);
    }
}