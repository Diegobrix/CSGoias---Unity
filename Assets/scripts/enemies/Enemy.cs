using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IShot
{
    public float maxEnemyLife;
    private float currentEnemyLife;

    private void Awake() {
        maxEnemyLife = 30f;
        currentEnemyLife = maxEnemyLife;
    }

    public void Hit(Vector3 direction, float damage)
    {
        GetShotted(direction, damage);
    }

    private void GetShotted(Vector3 shotOrigin, float gunDamage)
    {
        if(gunDamage >= currentEnemyLife)
        {
            Destroy(gameObject);
            return;
        }

        currentEnemyLife -= gunDamage;
    }
}
