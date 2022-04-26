using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public Tankview tankview;
    public TankScritableList tanklist;

    // Start is called before the first frame update
    void Start()
    {
        createTank();
    }

    private void createTank()
    {
        TankScritable tankScritable = tanklist.tanks[2];
        TankModel tankmodel = new TankModel(tankScritable);
        Tankcontroller tankcontroller = new Tankcontroller(tankview, tankmodel);
    }

}
