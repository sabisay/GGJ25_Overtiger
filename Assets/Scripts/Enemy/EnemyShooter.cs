using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Bullet bullet;

    private Raycastting _raycasting;
    private Transform _rayOriginTransform;

    // Update is called once per frame
    private void Start()
    {
        _rayOriginTransform = transform.GetChild(0);
        _raycasting = GetComponent<Raycastting>();
    }
    void Update()
    {
        if(_raycasting != null)
        {
            if (_raycasting.isHitted)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector3 direction = _raycasting.HittedObject.transform.position - _rayOriginTransform.position;
        bullet.SetDirection(direction);
        bullet.gameObject.SetActive(true);
    }
}
