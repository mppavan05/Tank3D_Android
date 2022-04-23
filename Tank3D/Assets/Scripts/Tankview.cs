using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankview : MonoBehaviour
{
    private Tankcontroller controller;
    private float movement;
    private float rotation;

    public Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("MainCam");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f,-4f);
        cam.transform.rotation = new Quaternion(15f, 0f, 0f, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (movement != 0)
            controller.Move(movement, controller.GetTankModel().movementSpeed);

        if (rotation != 0)
            controller.rotate(rotation, controller.GetTankModel().rotationSpeed);
        
    }

    //private void FixedUpdate()
    //{
     //   controller.Movement();
        
   // }

    private void Movement()
    {
        movement = Input.GetAxis("VerticalUI");
        rotation = Input.GetAxis("HorizontalUI");
    }

   public void SetController( Tankcontroller newController)
    {
        controller = newController;
    }
   

    void GetInput()
    {
        controller.Firing();

    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    
}
