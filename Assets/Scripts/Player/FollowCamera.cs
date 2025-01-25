using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Player;
    public float CameraSpeed = 15f;
    void LateUpdate()
    {
        Vector3 playerFollowPosition = new Vector3(
            Player.transform.position.x, 
            Player.transform.position.y + 1.5f,
            -10);
        transform.position = Vector3.Lerp(
            transform.position, 
            playerFollowPosition, 
            Time.deltaTime * CameraSpeed);
    }
}
