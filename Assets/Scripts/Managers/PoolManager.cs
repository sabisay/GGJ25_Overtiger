using System.Collections.Generic;
using UnityEngine;


public class PoolManager : MonoSingleton<PoolManager>
{
    public List<PlayerBullet> Bullets;

    private Vector3 aimDirection;
    
    public void GetAvailableBullet(Transform objectTransform)
    {
        foreach (PlayerBullet item in Bullets)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                item.transform.position = objectTransform.position;
                item.gameObject.SetActive(true);
                item.Fire(aimDirection);
                break;
            }
        }
    }

    public void Dimension(Vector3 vec) 
    {
        aimDirection = vec;
    }
}
