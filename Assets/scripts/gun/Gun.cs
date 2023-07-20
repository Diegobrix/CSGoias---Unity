using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float shootDistance = 20f;
    private Transform gunPosition;
    [SerializeField] private float gunDamage = 10f;

    private void Awake() {
        playerCamera = Camera.main;
        gunPosition = GetComponent<Transform>();
    }

    public void Shoot()
    {
        Ray ray = new Ray(playerCamera.transform.position, gunPosition.transform.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, shootDistance))
        {
            IShot shootedObj = hitInfo.collider.GetComponent<IShot>();

            if(shootedObj == null)
            {
                return;
            }

            shootedObj.Hit(playerCamera.transform.position, gunDamage);
        }
    }
}
