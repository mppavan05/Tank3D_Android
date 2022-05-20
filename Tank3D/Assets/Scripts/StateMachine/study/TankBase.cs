using System;
using UnityEngine;

public abstract class TankBase
{
    public abstract void EnterState(TankStates state);

    public abstract void UpdateState(TankStates state);

    public abstract void ExitState(TankStates state );

    public virtual void OnCollisionEnter(TankStates tankStates, Collision collision)
    {
        
    }
}
