using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public int waitSeconds = 2;
    public Transform initialPos;

    private Raycastting _raycastting;

    private void Start()
    {
        _raycastting = FindFirstObjectByType<Raycastting>();
        // initialPos = transform; // Baþlangýç pozisyonunu kaydediyoruz
    }
    private void OnEnable()
    {
        StartCoroutine(BulletDeactivated());
    }

    void Update()
    {

        Transform _targetObject = _raycastting.HittedObject.transform;
        transform.position = Vector2.MoveTowards(transform.position, _targetObject.position, speed * Time.deltaTime);
        
    }

    IEnumerator BulletDeactivated()
    {
        yield return new WaitForSeconds(waitSeconds);
        transform.position = initialPos.position;
        this.gameObject.SetActive(false);
    }
}
