using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public Tankview tankview;

    // Start is called before the first frame update
    void Start()
    {
        createTank();
    }

    private void createTank()
    {
        TankModel tankmodel = new TankModel(10 , 50);
        Tankcontroller tankcontroller = new Tankcontroller(tankview, tankmodel);
    }

}
