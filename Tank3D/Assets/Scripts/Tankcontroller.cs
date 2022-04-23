using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankcontroller 
{
    private Tankview _Tankview;
    private TankModle _Modle;

    public Tankcontroller(Tankview tankview)
    {
        _Tankview = Object.Instantiate(tankview);
        _Tankview.SetController(this);
        _Modle = new TankModle();
        _Modle.SetController(this);
    }
    public void Movement()
    {
        

    }

    public void Firing()
    {

    }
}
