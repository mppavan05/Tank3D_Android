using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyView : MonoBehaviour
{
    private EnemyController controller;
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_FireClip;
    private Chase chase;
    private TankStateController controllerState;

    private float m_CurrentHealth;
    private bool m_Dead;
    public float m_StartingHealth = 100f;
    public float lerpSpeed;
    public AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
    public ParticleSystem m_ExplosionParticles;
    public GameObject m_ExplosionPrefab;


    public NavMeshAgent navMeshAgent;               //  Nav mesh agent component
   
    public LayerMask playerMask;                    //  To detect the player with the raycast
    public LayerMask obstacleMask;                  //  To detect the obstacules with the raycast
   
    public Transform[] waypoints;                   //  All the waypoints where the enemy patrols
    public int m_CurrentWayPointIndex;                     //  Current waypoint where the enemy is going to

    public Image HealthBar;

    //static PatrolingMode patrolingMode = new PatrolingMode();
    //static ChasingMode chasingMode = new ChasingMode();




    void Start()
    {
        controller.m_playerPosition = Vector3.zero;
        controller.m_IsPatrol = true;
        controller.m_CaughPlayer = false;
        controller.m_playerInRange = false;
        controller.m_PlayerNear = false;

        //m_ExplosionParticles = GetComponent<ParticleSystem>();
        controller.m_WaitTime = controller.GetEnemyModle().startWaitTime;               //  Set the wait time variable that will change

        controller.m_TimeToRotate = controller.GetEnemyModle().timeToRotate;

        m_CurrentWayPointIndex = 0;                 //  Set the initial waypoint
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = controller.GetEnemyModle().speedWalk;             //  Set the navemesh speed with the normal speed of the enemy
        navMeshAgent.SetDestination(waypoints[m_CurrentWayPointIndex].position);    //  Set the destination to the first waypoint
        
    }

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void Update()
    {
        controller.EnviromentView();                       //  Check whether or not the player is in the enemy's field of vision

        if (!controller.m_IsPatrol)
        {
           // chasingMode.Chasing();
            Debug.Log("chasing");
        }
        else
        {
           // patrolingMode.Patroling();
            Debug.Log("patroling");
        }

        lerpSpeed = 3f * Time.deltaTime;

        SetHealthUI();
    }

    
    public void SetEnemyController(EnemyController enemycontroller)
    {
        controller = enemycontroller;
    }



    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        SetHealthUI();
    }

    public void SetHealthUI()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, m_CurrentHealth / m_StartingHealth, lerpSpeed);
        Color HealthColor = Color.Lerp(Color.red, Color.green, (m_CurrentHealth / m_StartingHealth));
        HealthBar.color = HealthColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shell")
            Takedamage(50f);
    }

    public void Takedamage(float amount)
    {
        m_CurrentHealth -= amount;
        SetHealthUI();

        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {

        m_Dead = true;
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        m_ExplosionParticles.Play();
        Debug.Log("explossion");

        // Play the tank explosion sound effect.


        //StartCoroutine(wait());
        m_ExplosionAudio.Play();
        // Turn the tank off.
        gameObject.SetActive(false);

        Destroy(gameObject);
        

    }

    /*IEnumerator wait()
    {
        yield return new WaitForSeconds(3);

        m_ExplosionAudio.Play();

        gameObject.SetActive(false);

        Destroy(gameObject);

    }*/










}
