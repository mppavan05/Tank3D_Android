using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public Tankview _tankview;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_tankview.gameObject, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
