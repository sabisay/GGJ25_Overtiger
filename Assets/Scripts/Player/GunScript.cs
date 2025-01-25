using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class GunScript : MonoBehaviour
{
    public InputActionReference shoot;
    public PlayerBullet Bullet;
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
