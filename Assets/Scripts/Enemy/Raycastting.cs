using UnityEngine;

public class Raycastting : MonoBehaviour
{
    public Transform rayOrigin; // Iþýnýn baþlangýç noktasý
    public Vector2 rayDirection = Vector2.right; // Iþýnýn yönü
    public float rayLength = 5f; // Iþýnýn uzunluðu
    public bool isHitted;
    public GameObject HittedObject;

    void Update()
    {
        // Ray'i oluþtur
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, -transform.forward, rayLength);

        // Ray'i çiz (her zaman kýrmýzý)
        Debug.DrawRay(rayOrigin.position, -transform.forward * rayLength, Color.red); //Ray'i görmek için Opsiyonel

        // Bir þeye çarptýysa log yazdýr
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
