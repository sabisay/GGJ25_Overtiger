using UnityEngine;

public class Raycastting : MonoBehaviour
{
    public Transform rayOrigin; // I��n�n ba�lang�� noktas�
    public Vector2 rayDirection = Vector2.right; // I��n�n y�n�
    public float rayLength = 5f; // I��n�n uzunlu�u
    public bool isHitted;
    public GameObject HittedObject;

    void Update()
    {
        // Ray'i olu�tur
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, -transform.forward, rayLength);

        // Ray'i �iz (her zaman k�rm�z�)
        Debug.DrawRay(rayOrigin.position, -transform.forward * rayLength, Color.red); //Ray'i g�rmek i�in Opsiyonel

        // Bir �eye �arpt�ysa log yazd�r
        if (hit.collider != null && !hit.collider.CompareTag("Bullet"))
        {
            //Debug.Log($"Hit {hit.collider.gameObject.tag} at {hit.point}");
            HittedObject = hit.collider.gameObject;
            isHitted = true;

        }
        else
        {
            isHitted = false;
        }
    }
}
