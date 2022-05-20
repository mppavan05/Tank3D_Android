using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : Base
{
    public override void EnterState(Statecontroller enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.agent.transform.position);
    }
    public override void UpdateState(Statecontroller enemyTankStateManager)
    {
        Attackfunction(enemyTankStateManager);
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.attackRange && enemyTankStateManager.attackRange < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    private void Attackfunction(Statecontroller enemyTankStateManager)
    {
        if (!enemyTankStateManager.isAlreadyAttacked)
        {
            enemyTankStateManager.EnemyTankView.FireFunction();
            enemyTankStateManager.isAlreadyAttacked = true;
            enemyTankStateManager.StartCoroutine(ResetAttack(enemyTankStateManager));
        }
    }

    private IEnumerator ResetAttack(Statecontroller enemyTankStateManager)
    {
        yield return new WaitForSecondsRealtime(enemyTankStateManager.timeBetweenAttack);
        enemyTankStateManager.isAlreadyAttacked = false;
    }
}
