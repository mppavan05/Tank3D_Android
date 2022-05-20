using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingMode : TankStateController
{
    /*public override void EnterState(TankStateController enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.agent.transform.position);
    }
    public override void UpdateState(TankStateController enemyTankStateManager)
    {
        Attackfunction(enemyTankStateManager);
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.attackRange && enemyTankStateManager.attackRange < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    private void Attackfunction(TankStateController enemyTankStateManager)
    {
        if (!enemyTankStateManager.isAlreadyAttacked)
        {
            enemyTankStateManager.EnemyTankView.FireFunction();
            enemyTankStateManager.isAlreadyAttacked = true;
            enemyTankStateManager.StartCoroutine(ResetAttack(enemyTankStateManager));
        }
    }

    private IEnumerator ResetAttack(TankStateController enemyTankStateManager)
    {
        yield return new WaitForSecondsRealtime(enemyTankStateManager.timeBetweenAttack);
        enemyTankStateManager.isAlreadyAttacked = false;
    }*/

}
