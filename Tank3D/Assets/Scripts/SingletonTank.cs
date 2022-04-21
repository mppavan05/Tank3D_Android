using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTank<T> : MonoBehaviour where T : SingletonTank<T>
{
    private static T Instance;
    public static T _Instance { get { return Instance; } }

    private void Awake()
    {

        if(Instance == null)
        {
            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}