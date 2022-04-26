using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankview : MonoBehaviour
{
    [HideInInspector] public GameObject m_Instance;
    private Tankcontroller controller;
    private float movement;
    private float rotation;


    public Rigidbody rb;
    public TankTypes types;
    public Color m_PlayerColor;


    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("MainCam");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f,-4f);
        
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
