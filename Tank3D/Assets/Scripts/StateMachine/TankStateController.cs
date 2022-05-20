using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankStateController : MonoBehaviour
{
    public EnemyController controller;
    public PatrolingMode patroling; //= new PatrolingMode();
    public ChasingMode chasing; //= new ChasingMode();
   // public AttackingMode attacking = new AttackingMode();
    
    public void SetEnemyController(EnemyController enemycontroller)
    {
        controller = enemycontroller;  
    }
   
    public  ChasingMode GetChasingMode()
    {
        //ChasingMode chasing = new ChasingMode();
        return chasing;
    }

    public PatrolingMode GetPatrolingMode()
    {
        //PatrolingMode patroling = new PatrolingMode();
        return patroling;
    }


    
    

}
