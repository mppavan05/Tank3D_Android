using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : TankBase
{
    Vector3 startingSize = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 grownSize = new Vector3(0.1f, 0.1f, 0.1f);
    public override void EnterState(TankStates state)
    {
        Debug.Log("chase");
        state.transform.localScale = startingSize;
    }


    public override void UpdateState(TankStates state)
    {
        if(state.transform.localScale.x <1)
        {
            state.transform.localScale += grownSize * Time.deltaTime;
        }
        else
        {
            state.SwitchState(state.tankPatrol);
        }
        
    }
    public override void ExitState(TankStates state)
    {
        
    }

    public override void OnCollisionEnter(TankStates state, Collision collision)
    {
        
    }
}
