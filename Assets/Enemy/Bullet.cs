using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public int waitSeconds = 2;
    public Transform initialPos;
    
    private Vector3 _moveDirection;

    private void OnEnable()
    {
        StartCoroutine(BulletDeactivated(waitSeconds));
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;

    }

    IEnumerator BulletDeactivated(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        transform.position = initialPos.position;
        this.gameObject.SetActive(false);
    }
}
