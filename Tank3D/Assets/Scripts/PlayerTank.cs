using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : SingletonTank<PlayerTank>
{
    public float rotateSpeed = 90;
    public float speed = 5.0f;
    public Joystick joystick;


    void Update()
    {
        var transAmount = speed * Time.deltaTime;
        var rotateAmount = rotateSpeed * Time.deltaTime;

        if (joystick.Horizontal >= 0.2f)
        {
            transform.Translate(0, 0, transAmount);
        }
        if (joystick.Horizontal <= -0.2f)
        {
            transform.Translate(0, 0, -transAmount);
        }
        if (joystick.Vertical >= 0.5f)
        {
            transform.Rotate(0, -rotateAmount, 0);
        }
        if (joystick.Vertical <= -0.5f)
        {
            transform.Rotate(0, rotateAmount, 0);
        } 

       /* float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);*/
    }
}

