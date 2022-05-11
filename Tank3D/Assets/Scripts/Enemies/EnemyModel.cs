public class EnemyModel 
{
    private EnemyController controller;

    public string EnemyName;

    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;
    public float viewRadius = 23;
    public float viewAngle = 120;
    public float meshResolution = 1.0f;
    public float edgeIterration = 4;
    public float edgeDistane = 0.5f;
    public float m_MinLaunchForce = 15f;







    public void SetEnemyController(EnemyController enemycontroller)
    {
        controller = enemycontroller;
    }



    public EnemyModel(TankScritable tankScritable)
    {
        EnemyName = tankScritable.EnemyName;
        
    }

    public EnemyModel(string Enemyname)
    {
        Enemyname=EnemyName;
    }
   
}
