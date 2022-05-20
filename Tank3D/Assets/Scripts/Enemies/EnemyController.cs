using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : TankStateController
{
    
    public EnemyView enemyview;
    public EnemyModel enemymodle;
    public TankStateController tankstatecontroller;
    public bool m_Fired;
    public float m_CurrentLaunchForce;

    public EnemyModel GetEnemyModle()
    {
        return enemymodle;
    }

   



    public EnemyController(EnemyModel _enemymodel, EnemyView _enemyview, Vector3 spawnPlayer)
    {
        enemymodle = _enemymodel;
        enemyview = _enemyview;
        

        if (enemymodle != null)
        {
            enemyview = GameObject.Instantiate<EnemyView>(_enemyview);
        }

        _enemyview.transform.position = spawnPlayer;
        enemyview.SetEnemyController(this);
        enemymodle.SetEnemyController(this);
        tankstatecontroller.SetEnemyController(this);
        
    }

    

    public Vector3 playerLastPosition = Vector3.zero;
    public Vector3 m_playerPosition;


    public float m_WaitTime;
    public float m_TimeToRotate;
    public bool m_playerInRange;
    public bool m_PlayerNear;
    public bool m_IsPatrol;
    public bool m_CaughPlayer;






   
       /*public void Chasing()
        {


            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;

            if (!m_CaughPlayer)
            {

                Move(enemymodle.speedRun);
                enemyview.navMeshAgent.SetDestination(m_playerPosition);

            }
            if (enemyview.navMeshAgent.remainingDistance <= enemyview.navMeshAgent.stoppingDistance)
            {

                if (m_WaitTime <= 0 && !m_CaughPlayer && Vector3.Distance(enemyview.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
                {

                    m_IsPatrol = true;
                    m_PlayerNear = false;
                    Move(enemymodle.speedWalk);
                    m_TimeToRotate = enemymodle.timeToRotate;
                    m_WaitTime = enemymodle.startWaitTime;
                    enemyview.navMeshAgent.SetDestination(enemyview.waypoints[enemyview.m_CurrentWayPointIndex].position);
                }
                else
                {
                    if (Vector3.Distance(enemyview.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                    {

                        Stop();
                        m_WaitTime -= Time.deltaTime;
                    }
                }
            }
        }*/
    


    public void NextPoint()
    {
        enemyview.m_CurrentWayPointIndex = (enemyview.m_CurrentWayPointIndex + 1) % enemyview.waypoints.Length;
        enemyview.navMeshAgent.SetDestination(enemyview.waypoints[enemyview.m_CurrentWayPointIndex].position);
    }


    /*public void Patroling()
    {
        
        
        if (m_PlayerNear)
        {
            if (m_TimeToRotate <= 0)
            {
                Move(enemymodle.speedWalk);
                lookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;
            playerLastPosition = Vector3.zero;
            enemyview.navMeshAgent.SetDestination(enemyview.waypoints[enemyview.m_CurrentWayPointIndex].position);
            if (enemyview.navMeshAgent.remainingDistance <= enemyview.navMeshAgent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(enemymodle.speedWalk);
                    m_WaitTime = enemymodle.startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }*/

    public void Move(float speed)
    {
        enemyview.navMeshAgent.isStopped = false;
        enemyview.navMeshAgent.speed = speed;
    }

    public void Stop()
    {
        enemyview.navMeshAgent.isStopped = true;
        enemyview.navMeshAgent.speed = 0;
    }

   

    void CaughtPlayer()
    {
        m_CaughPlayer = true;
    }

    public void lookingPlayer(Vector3 player)
    {
        
        enemyview.navMeshAgent.SetDestination(player);
        if (Vector3.Distance(enemyview.transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                
                m_PlayerNear = false;
                Move(enemymodle.speedWalk);
                enemyview.navMeshAgent.SetDestination(enemyview.waypoints[enemyview.m_CurrentWayPointIndex].position);
                m_WaitTime = enemymodle.startWaitTime;
                m_TimeToRotate = enemymodle.timeToRotate;
            }

            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    
    public void EnviromentView()
    {
        
        Collider[] playerInRange = Physics.OverlapSphere(enemyview.transform.position, enemymodle.viewRadius, enemyview.playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - enemyview.transform.position).normalized;
            if (Vector3.Angle(enemyview.transform.forward, dirToPlayer) < enemymodle.viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(enemyview.transform.position, player.position);
                if (!Physics.Raycast(enemyview.transform.position, dirToPlayer, dstToPlayer, enemyview.obstacleMask))
                {
                    m_playerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    m_playerInRange = false;
                }
            }
            if (Vector3.Distance(enemyview.transform.position, player.position) > enemymodle.viewRadius)
            {
                m_playerInRange = false;
            }


            if (m_playerInRange)
            {
                
                m_playerPosition = player.transform.position;
            }
        }
        Debug.Log(m_IsPatrol);
    }


    public void Fire(Rigidbody m_Shell, Transform m_FireTransform)
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance = Object.Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward; ;

        // Change the clip to the firing clip and play it.
        enemyview.m_ShootingAudio.clip = enemyview.m_FireClip;
        enemyview.m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = enemymodle.m_MinLaunchForce;
    }





}
