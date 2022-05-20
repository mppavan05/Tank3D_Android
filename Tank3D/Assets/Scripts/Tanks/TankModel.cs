public class TankModel 
{
    private Tankcontroller controller;
    //private TankType tanktype;

    public float movementSpeed;
    public float rotationSpeed;
    public float Health;

    public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 30f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.


    public float[] GetFireDetails()
    {
        float[] fireDetails = new float[3];
        fireDetails[0] = m_MinLaunchForce;
        fireDetails[1] = m_MaxLaunchForce;
        fireDetails [2] = m_MaxChargeTime;
        return fireDetails;
    }
   
    public TankTypes TankType { get; }

    public TankModel(TankScritable tankScritable)
    {
        TankType = tankScritable.tankType;
        movementSpeed = tankScritable.Speed;
        Health = tankScritable.StartingHealth;
        rotationSpeed = tankScritable.rotationSpeed;

    }
    public TankModel(TankTypes tanktype,float _movement , float _rotation , float health )
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
        Health = health;

        
        
    }

    public void SetController(Tankcontroller newController)
    {
        controller = newController;
        
    }


 
   


}
