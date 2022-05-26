using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;  // to access in all the class
    private Queue<GameObject> pooledObject = new Queue<GameObject>();  // private list for pooled game object
    private int amountToPool = 20;    // private intiger for amount

    [SerializeField] private GameObject Bulletprefab;    // referance of the game object to be pooled
    private void Awake()
    {
        if(instance == null)             // if its null
        {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i < amountToPool; i++)     // set a length to the object
        {
            GameObject Bulletprf = Instantiate(Bulletprefab);   // instantiate object to be pool and store it in a game object

            pooledObject.Enqueue(Bulletprf);
            Bulletprf.SetActive(false);
        }
    }

    public GameObject GetpooledObject()
    {
        if(pooledObject.Count > 0)
        {
            GameObject Bulletprf = pooledObject.Dequeue();
            Bulletprf.SetActive(true);
            return Bulletprf;
        }
        else
        {
            GameObject Bulletprf = Instantiate(Bulletprefab);
            return Bulletprf;
        }
    }

    public void ReturnBulletprf(GameObject Bulletprf)
    {
        pooledObject.Enqueue(Bulletprf);
        Bulletprf.SetActive(false);
    }
}
