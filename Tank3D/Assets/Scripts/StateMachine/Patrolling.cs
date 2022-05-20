using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : Base
{
    public override void EnterState(Statecontroller enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Patrolling State...");
        EnemyPatrol(enemyTankStateManager);
    }
    public override void UpdateState(Statecontroller enemyTankStateManager)
    {
        if (enemyTankStateManager.agent.remainingDistance <= enemyTankStateManager.agent.stoppingDistance)
        {
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }

        if (enemyTankStateManager.distToPlayer < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    void EnemyPatrol(Statecontroller enemyTankStateManager)
    {
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoint").transform;

        foreach (Transform wP in wayPointsObject)
        {
            enemyTankStateManager.wayPoints.Add(wP);
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }
    }

}
