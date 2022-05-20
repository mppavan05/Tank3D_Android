using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaseing : Base
{
    public override void EnterState(Statecontroller enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Chase State...");
    }
    public override void UpdateState(Statecontroller enemyTankStateManager)
    {
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.player.position);
        CheckEnemyAttack(enemyTankStateManager);
        CheckEnemyPatrol(enemyTankStateManager);
    }

    private void CheckEnemyAttack(Statecontroller enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer <= enemyTankStateManager.attackRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.attackState);
        }
    }
    private void CheckEnemyPatrol(Statecontroller enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.patrollingState);
        }

    }
}
