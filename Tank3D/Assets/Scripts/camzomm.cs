using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camzomm : MonoBehaviour
{
    public new Camera camera;
    public float speed = 1;

    private bool buttonRelized;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            buttonRelized = false;
            if(camera.fieldOfView >= 80)
            {
                camera.fieldOfView -= 1;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            buttonRelized=true;
        }

        if(buttonRelized)
        {
            if(camera.fieldOfView <= 70)
            {
                camera.fieldOfView += 1;
            }
            
        }

        // public void HandleRightJoyStickInput(Transform turretTransform)
        // {
        //    Vector3 desiredRotation = Vector3.up * RightJoyStick.Horizontal * TankModel.TurretRotationSpeed * RotationSpeedMultiplier;
        //    turretTransform.Rotate(desiredRotation, Space.Self);
        // }

        /* private async void DestroyTanks()
         {
             GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
             for (int i = 0; i < tanks.Length; i++)
             {
                 TankView.TExplode.transform.parent = null;

                 TankView.TExplode.Play();

                 GameObject.Destroy(tanks[i]);



                 Debug.Log("DEad");
                 await new WaitForSeconds(0.1f);
             }
         }

         private async void DestoryEnv()
     {
         GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
         for (int i = 0; i < objects.Length; i++)
         {
             GameObject.Destroy(objects[i]);
             await new WaitForSeconds(0.05f);
         }
     }


         */


    }
}

    
    
        
    

