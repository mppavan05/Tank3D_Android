using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base
{
    public abstract void EnterState(Statecontroller enemyTankStateManager);
    public abstract void UpdateState(Statecontroller enemyTankStateManager);
}
