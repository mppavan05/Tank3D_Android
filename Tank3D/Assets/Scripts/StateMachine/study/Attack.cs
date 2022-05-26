using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : TankBase
{
    public override void EnterState(TankStates state)
    {
        Debug.Log("Attack");
    }

    public override void UpdateState(TankStates state)
    {

    }

    public override void ExitState(TankStates state)
    {

    }

    public override void OnCollisionEnter(TankStates state, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            state.SwitchState(state.tankChase);
        }
    }
}
