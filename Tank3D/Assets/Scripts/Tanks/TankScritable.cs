using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TankScritable" ,menuName = "ScriptableObjects/NewTankScriptableObjects")]
public class TankScritable : ScriptableObject
{
    public TankTypes tankType;
    public string TankName;
    public float Speed;
    public float rotationSpeed;
    public float StartingHealth;
    public float Damage;
    public string EnemyName;
    public float minLaunchForce;// = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    public float currentLaunchForce;
    public float chargeSpeed;

}



