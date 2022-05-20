using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolingMode : TankStateController
{
    
    public void Patroling()
    {


        if (controller.m_PlayerNear)
        {
            if (controller.m_TimeToRotate <= 0)
            {
                controller.Move(controller.enemymodle.speedWalk);
                controller.lookingPlayer(controller.playerLastPosition);
            }
            else
            {
                controller.Stop();
                controller.m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            controller.m_PlayerNear = false;
            controller.playerLastPosition = Vector3.zero;
            controller.enemyview.navMeshAgent.SetDestination(controller.enemyview.waypoints[controller.enemyview.m_CurrentWayPointIndex].position);
            if (controller.enemyview.navMeshAgent.remainingDistance <= controller.enemyview.navMeshAgent.stoppingDistance)
            {
                if (controller.m_WaitTime <= 0)
                {
                    controller.NextPoint();
                    controller.Move(controller.enemymodle.speedWalk);
                    controller.m_WaitTime = controller.enemymodle.startWaitTime;
                }
                else
                {
                    controller.Stop();
                    controller.m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }




}
