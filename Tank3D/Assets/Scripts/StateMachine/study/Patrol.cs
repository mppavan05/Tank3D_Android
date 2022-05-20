using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : TankBase
{
    float Countdown = 10.0f;
    public override void EnterState(TankStates state)
    {
        Debug.Log("Patrol");
       state.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void UpdateState(TankStates state)
    {
        if(Countdown >= 0)
        {
            Countdown -= Time.deltaTime;
        }
        else
        {
            state.SwitchState(state.tankAttack);
        }
    }

    public override void ExitState(TankStates state)
    {
        
    }

    public override void OnCollisionEnter(TankStates state, Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Player"))
        {
            state.SwitchState(state.tankAttack);
        }
    }
}
