using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMode : TankStateController
{
    public void Chasing()
    {

        controller.m_PlayerNear = false;
        controller.playerLastPosition = Vector3.zero;

        if (!controller.m_CaughPlayer)
        {

            controller.Move(controller.enemymodle.speedRun);
            controller.enemyview.navMeshAgent.SetDestination(controller.m_playerPosition);

        }
        if (controller.enemyview.navMeshAgent.remainingDistance <= controller.enemyview.navMeshAgent.stoppingDistance)
        {

            if (controller.m_WaitTime <= 0 && !controller.m_CaughPlayer && Vector3.Distance(controller.enemyview.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {

                controller.m_IsPatrol = true;
                controller.m_PlayerNear = false;
                controller.Move(controller.enemymodle.speedWalk);
                controller.m_TimeToRotate = controller.enemymodle.timeToRotate;
                controller.m_WaitTime = controller.enemymodle.startWaitTime;
                controller.enemyview.navMeshAgent.SetDestination(controller.enemyview.waypoints[controller.enemyview.m_CurrentWayPointIndex].position);
            }
            else
            {
                if (Vector3.Distance(controller.enemyview.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {

                    controller.Stop();
                    controller.m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }

}
