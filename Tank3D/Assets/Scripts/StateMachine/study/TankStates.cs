using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(EnemyView))]
public class TankStates : MonoBehaviour
{

    //public EnemyView enemyview;
    //public EnemyController controller;
    TankBase currentState;
    public Patrol tankPatrol = new Patrol();
    public Chase tankChase = new Chase();
    public Attack tankAttack = new Attack();

   // public void SetEnemyController(EnemyController enemycontroller)
    //{
    //    controller = enemycontroller;
    //}

    public void Start()
    {
        currentState = tankChase;

        currentState.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(TankBase State)
    {
        currentState = State;
        State.EnterState(this);
        
    }

}


