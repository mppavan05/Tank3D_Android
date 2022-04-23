using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankview : MonoBehaviour
{
    private Tankcontroller controller;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        controller.Movement();
        
    }

   public void SetController( Tankcontroller newController)
    {
        controller = newController;
    }
   

    void GetInput()
    {
        controller.Firing();

    }

    
}
