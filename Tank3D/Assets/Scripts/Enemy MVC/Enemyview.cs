using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


//[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Rigidbody))]
public class Enemyview : MonoBehaviour , IDamagable
{
    public TankTypes tankType;
    public Enemycontroller EnemyTankController;

    //public Slider sliderHealth;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    public Rigidbody shellPrefab;
    public Transform fireTransform;
   // public Slider aimSlider;

    private IEnumerator coroutine;

    internal bool fire1 = false;
    internal bool fire0 = false;
    internal bool fire3 = false;

    public bool fired;
    internal bool enemyTankDead;
    private void Start()
    {
        InitializeComponenets();
        //Debug.Log("EnemyTank View Created");
        //EnemyTankController.StartFunction();
    }
    private void InitializeComponenets()
    {
        //rb = GetComponent<Rigidbody>();
    }
    public void FireFunction()
    {
        EnemyTankController.Fire();
    }
    void IDamagable.TakeDamage(float damage)
    {
        //Debug.Log("EnemyTank Taking Damage" + damage);
        EnemyTankController.ApplyDamage(damage);
    }

}
