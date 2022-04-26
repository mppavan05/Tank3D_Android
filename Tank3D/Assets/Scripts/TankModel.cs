public class TankModel 
{
    private Tankcontroller controller;
    //private TankType tanktype;

    public float movementSpeed;
    public float rotationSpeed;
    public float Health;
    

    public TankTypes TankType { get; }

    public TankModel(TankScritable tankScritable)
    {
        TankType = tankScritable.tankType;
        movementSpeed = tankScritable.Speed;
        Health = tankScritable.Health;
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
