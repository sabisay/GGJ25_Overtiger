using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;

    private Raycastting _raycasting;

    // Update is called once per frame
    private void Start()
    {
        _raycasting = FindFirstObjectByType<Raycastting>();
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
        bullet.SetActive(true);
    }
}
