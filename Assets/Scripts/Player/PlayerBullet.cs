using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 15f;
    private Vector3 _movement;

    public void Fire(Vector3 direction)
    {
        _movement = direction * Time.deltaTime * speed;
    }

    private void Update()
    {
        transform.position += _movement;
    }

    private void OnEnable()
    {
        StartCoroutine(Deactive());
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
