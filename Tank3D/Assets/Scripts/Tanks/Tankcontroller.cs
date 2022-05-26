using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankcontroller
{
    private Tankview tankview;
    private TankModel tankmodel;
    private Rigidbody rb;
    private float m_ChargeSpeed;
    public bool m_Fired;
    public float m_CurrentLaunchForce;
    //public ObjectPool objectPool;
    //-------------------------------------------------------------------//
    //Enemey movement & AI
    

    //------------------------------------------------------------------//

    public Tankcontroller(Tankview _tankview, TankModel _tankmodel)
    {
        tankmodel = _tankmodel;
        if(tankmodel != null)
        {
             tankview = GameObject.Instantiate<Tankview>(_tankview);
        }
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
  

    


    public float CalculateChargeSpeed()
    {
        float[] fireDetails = new float[3];
        fireDetails = tankmodel.GetFireDetails();
        m_ChargeSpeed = (fireDetails[1] - fireDetails[0]) / fireDetails[2];
        return m_ChargeSpeed;
        
    }


    public void Fire(Rigidbody m_Shell, Transform m_FireTransform)
    {
        
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody shellInstance = Object.Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        //shellInstance = tankview.objectPool.GetpooledObject();
        
        // GameObject newBullet = tankview.objectPool.GetpooledObject();
        //newBullet.transform.position = m_FireTransform.position;
        ////Rigidbody Bullet = newBullet.gameObject.Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
        ////Bullet.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        // Change the clip to the firing clip and play it.
        tankview.m_ShootingAudio.clip = tankview.m_FireClip;
        tankview.m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = tankmodel.m_MinLaunchForce;
    }



 }

