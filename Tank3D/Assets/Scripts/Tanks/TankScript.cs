using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankScript : MonoBehaviour
{
    public Tankview tankview;
    public TankScritableList tanklist;
    public Enemyview EnemyTankView;
    public Enemymodel EnemyTankModel;
    public int numOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
           createEnemy();
        }
        createTank();
    }

    private void createTank()
    {
        TankScritable tankScritable = tanklist.tanks[2];

        TankModel tankmodel = new TankModel(tankScritable);
        Tankcontroller tankcontroller = new Tankcontroller(tankview, tankmodel);
        
        
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

  
    private Enemycontroller createEnemy()
    {
        int index = Random.Range(0, tanklist.tanks.Length);
        TankScritable tankScriptableObject = tanklist.tanks[index];
        //Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        EnemyTankModel = new Enemymodel(tankScriptableObject);
        Enemycontroller enemyTank = new Enemycontroller(EnemyTankModel, EnemyTankView, RandomPosition());
        return enemyTank;
    }

}
