using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera playerCamera;
    private Transform gunPosition;

    public GunParamsController gunParameters;
    public int gunId;

    protected virtual void Awake()
    {
        playerCamera = Camera.main;
        gunPosition = GetComponent<Transform>();
    }

    public void Shoot()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hitInfo;
        
        if(Physics.Raycast(ray, out hitInfo, gunParameters.guns[gunId].shootDistance))
        {
            IShot shootedObj = hitInfo.collider.GetComponent<IShot>();

            if(shootedObj == null)
            {
                return;
            }

            shootedObj.Hit(playerCamera.transform.position, gunParameters.guns[gunId].gunDamage);
        }
    }
}
