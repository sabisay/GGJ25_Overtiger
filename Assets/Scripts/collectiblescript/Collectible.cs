using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum Collectibles
    {
        su,
        sabun
    }

    public Collectibles m_Collectibles;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(m_Collectibles == Collectibles.su)
                PlayerHealthSystem.Instance.AddWater(1);
            else
            {
                PlayerHealthSystem.Instance.AddSoap(1);
            }
            Destroy(gameObject);
        }
    }
}
