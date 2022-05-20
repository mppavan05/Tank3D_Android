using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankScript : MonoBehaviour
{
    public Tankview tankview;
    public TankScritableList tanklist;
    public EnemyView enemyview;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
           createEnemy(i);
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

    private void createEnemy(int i)
    {
        TankScritable tankScritable = tanklist.tanks[i];
        EnemyModel enemyModle = new EnemyModel(tankScritable);
        
        EnemyController enemyController = new EnemyController(enemyModle, enemyview, RandomPosition());

    }

}
