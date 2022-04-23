public class TankModel 
{
    private Tankcontroller controller;

    public float movementSpeed;
    public float rotationSpeed;

    public TankModel(float _movement , float _rotation)
    {
        movementSpeed = _movement;
        rotationSpeed = _rotation;
    }

    public void SetController(Tankcontroller newController)
    {
        controller = newController;
    }
}
