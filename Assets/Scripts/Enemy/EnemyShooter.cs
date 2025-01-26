using System;
using System.Collections;
using UnityEngine;

public enum SelectedType
{
    Soap,
    Water
}
public class EnemyShooter : MonoBehaviour
{
    //public AudioSource shootmusic;

    public Bullet bullet;
    public GameObject CollectibleParent;
    public SelectedType SelectedType;

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
        //shootmusic.Play();

        Vector3 direction = _raycasting.HittedObject.transform.position - _rayOriginTransform.position;
        bullet.SetDirection(direction);
        bullet.gameObject.SetActive(true);
    }

    public void Die()
    {
        int selectedNumber = SelectedType == SelectedType.Soap ? 0 : 1;
        GameObject SelectedCollectible = CollectibleParent.transform.GetChild(selectedNumber).gameObject;
        SelectedCollectible.gameObject.SetActive(true);
        SelectedCollectible.gameObject.transform.SetParent(null);
        transform.gameObject.SetActive(false);
    }
}
