using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Statecontroller : MonoBehaviour
{
    public Base currentState;
    public Patrolling patrollingState = new Patrolling();
    public Chaseing chaseState = new Chaseing();
    public Attacking attackState = new Attacking();

    internal Enemyview EnemyTankView;

    public NavMeshAgent agent;
    public List<Transform> wayPoints = new List<Transform>();
    internal Transform player;

    public float distToPlayer;
    public float chaseRange;
    public float attackRange;

    public float timeBetweenAttack = 2f;
    public bool isAlreadyAttacked = false;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        EnemyTankView = GetComponent<Enemyview>();
        player = FindObjectOfType<Tankview>().transform;

        currentState = patrollingState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        CheckPlayer();
        currentState.UpdateState(this);
    }

    private void CheckPlayer()
    {
        if (player == null)
        {
            currentState = patrollingState;
            return;
        }
        distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
    }

    public void SwitchState(Base enemyTankBaseState)
    {
        currentState = enemyTankBaseState;
        enemyTankBaseState.EnterState(this);
    }


}
