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

    private void createEnemy(int i)
    {
        TankScritable tankScritable = tanklist.tanks[i];
        EnemyModel enemyModle = new EnemyModel(tankScritable);
        EnemyController enemyController = new EnemyController(enemyModle, enemyview);

    }

}
