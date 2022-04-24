using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankcontroller 
{
    private Tankview tankview;
    private TankModel tankmodel;
    private Rigidbody rb;

    public Tankcontroller(Tankview _tankview, TankModel _tankmodel)
    {
        tankmodel = _tankmodel;
        tankview = GameObject.Instantiate<Tankview>(_tankview);
        rb = tankview.GetRigidbody();


        tankmodel.SetController(this);
        tankview.SetController(this);

        
    }
    public void Move(float movement, float movementSpeed) 
    {
        
        rb.velocity = tankview.transform.forward * movement * movementSpeed;
    }

    public void rotate(float rotate, float rotateSpeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel()
    {
        return tankmodel;
    }

    public void Firing()
    {

    }
}
