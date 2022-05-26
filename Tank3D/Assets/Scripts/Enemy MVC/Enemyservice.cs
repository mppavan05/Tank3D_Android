using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyservice : MonoBehaviour
{
  /* // public Enemyview EnemyTankView;
    //private Enemymodel EnemyTankModel;
   // public int numOfEnemies;

    //public Transform spawnEnemy;

    //public TankScritableList tankScriptableObjectList;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            CreateEnemyTank();
        }
    }
    Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = Random.Range(-35, 35);
        y = 1;
        z = Random.Range(-20, 30);
        pos = new Vector3(x, y, z);
        return pos;
    }

    private Enemycontroller CreateEnemyTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScritable tankScriptableObject = tankScriptableObjectList.tanks[index];
        //Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        EnemyTankModel = new Enemymodel(tankScriptableObject);
        Enemycontroller enemyTank = new Enemycontroller(EnemyTankModel, EnemyTankView, RandomPosition());
        return enemyTank;
    }*/
}
