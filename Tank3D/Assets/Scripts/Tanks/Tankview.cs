using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tankview : MonoBehaviour
{

    private Tankcontroller controller;
    private float movement;// na
    private float rotation;//na
    public AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
    public ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.
    private float m_CurrentHealth;   //na                   // How much health the tank currently has.
    private bool m_Dead;//na
    private string m_FireButton;  //na              // The input axis that is used for launching shells.
  
    private int m_PlayerNumber = 1;              // Used to identify the different players.

    public Rigidbody rb;
    public TankTypes types;// na

    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
   
    public Image HealthBar;
   
    float lerpSpeed;
    public GameObject m_ExplosionPrefab;
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.



    
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("MainCam");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);

        // The fire axis is based on the player number.
        m_FireButton = "Fire" + m_PlayerNumber;

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        //m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        controller.CalculateChargeSpeed();
        

    }
    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
        // When the tank is turned on, reset the launch force and the UI
        
        //controller.m_CurrentLaunchForce = controller.GetTankModel().m_MinLaunchForce;
        //m_AimSlider.value = controller.GetTankModel().m_MinLaunchForce;

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (movement != 0)
            controller.Move(movement, controller.GetTankModel().movementSpeed);

        if (rotation != 0)
            controller.rotate(rotation, controller.GetTankModel().rotationSpeed);

        m_AimSlider.value = controller.GetTankModel().m_MinLaunchForce;
        if (controller.m_CurrentLaunchForce >= controller.GetTankModel().m_MaxLaunchForce && controller!.m_Fired)
        {
            controller.m_CurrentLaunchForce = controller.GetTankModel().m_MaxLaunchForce;
            controller.Fire(m_Shell, m_FireTransform);
        }
        else if (Input.GetButtonDown(m_FireButton))
        {
            controller.m_Fired = false;
            controller.m_CurrentLaunchForce = controller.GetTankModel().m_MinLaunchForce;
            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();
        }
        else if (Input.GetButton(m_FireButton) )//&& controller!.m_Fired)
        {
            controller.m_CurrentLaunchForce += controller.CalculateChargeSpeed() * Time.deltaTime;
            m_AimSlider.value = controller.m_CurrentLaunchForce;
        }
        else if (Input.GetButtonUp(m_FireButton) )// && controller!.m_Fired)
        {
            controller.Fire(m_Shell,m_FireTransform);
        }

        lerpSpeed = 3f * Time.deltaTime;

        SetHealthUI();
        
    }

   

    private void Movement()
    {
        movement = Input.GetAxis("VerticalUI");
        rotation = Input.GetAxis("HorizontalUI");
    }
    public void SetController(Tankcontroller newController)
    {
        controller = newController;
    }



    public Rigidbody GetRigidbody()
    {
        return rb;
    }


    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }




    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;
        SetHealthUI();

        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }


    private void SetHealthUI()
    { 
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, m_CurrentHealth / m_StartingHealth, lerpSpeed);
        Color HealthColor = Color.Lerp(Color.red , Color.green, (m_CurrentHealth/ m_StartingHealth));
        HealthBar.color = HealthColor;
    }



  


    private void OnDeath()
    {
       
        m_Dead = true;
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        m_ExplosionParticles.Play();

        // Play the tank explosion sound effect.
        m_ExplosionAudio.Play();

        // Turn the tank off.
        gameObject.SetActive(false);

        Destroy(gameObject);
        
    }




    





}
