using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GUN_DATA
{
    public float shootDistance;
    public float gunDamage;
    public string gunName;
}

[CreateAssetMenu(fileName = "GunParamsController", menuName = "CSGoias/GunParamsController", order = 1)]
public class GunParamsController : ScriptableObject
{
    public List<GUN_DATA> guns; 
}
