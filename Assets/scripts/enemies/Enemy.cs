using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IShot
{
    public void Hit(Vector3 direction)
    {

    }

    private void GetShotted(Vector3 shotOrigin)
    {
        Debug.Log(shotOrigin);
    }
}
