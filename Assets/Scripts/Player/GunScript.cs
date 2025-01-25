using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class GunScript : MonoBehaviour
{
    public InputActionReference shoot;
    public Bullet Bullet;
    private Transform aimTransform;
    private Vector3 aimDirection;

    private void OnEnable()
    {
        shoot.action.performed += Shoot;
    }
    private void OnDisable()
    {
        shoot.action.performed -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        PoolManager.Instance.Dimension(aimDirection);
        PoolManager.Instance.GetAvailableBullet(transform);

        // PoolManager.Instance.GetAvailableBullet(transform);
        //Debug.Log("sa");
        /*
         var bullet = PoolManager.Instance.GetAvailableBullet(transform);
        if (bullet != null)
            bullet.Fire(aimDirection);
        else
            Debug.Log("Mermi boþ");
        foreach (var item in PoolManager.Instance.Bullets)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                item.transform.position = transform.position;
                item.gameObject.SetActive(true);
                item.Fire(aimDirection);
                break;
            }
        }
        */
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3 (0, 0, angle);
    }


}
