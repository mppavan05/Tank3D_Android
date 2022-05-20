using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymodel 
{
    public TankTypes TankType { get; }
    //private int playerID { get;}

    public Color TankColor { get; }
    internal float currentHealth;
    public float TankSpeed { get; } // public get; private set
    public float TankTurnSpeed { get; }
    public float TankHealth { get; }
    public float MinLaunchForce { get; }
    public float MaxLaunchForce { get; }
    public float MaxChargeTime { get; }
    public float CurrentLaunchForce { get; set; }
    public float ChargeSpeed { get; set; }

    public Vector3 TankSize;

    public Enemymodel(TankScritable tankScriptableObject)
    {
        TankType = tankScriptableObject.tankType;
       // TankSize = tankScriptableObject.scale;
       // TankColor = tankScriptableObject.color;

        TankSpeed = tankScriptableObject.Speed;
        TankTurnSpeed = tankScriptableObject.rotationSpeed;
        TankHealth = tankScriptableObject.StartingHealth;
        MinLaunchForce = tankScriptableObject.minLaunchForce;
        MaxLaunchForce = tankScriptableObject.maxLaunchForce;
        MaxChargeTime = tankScriptableObject.maxChargeTime;

        CurrentLaunchForce = tankScriptableObject.currentLaunchForce;
        ChargeSpeed = tankScriptableObject.chargeSpeed;
    }

}
