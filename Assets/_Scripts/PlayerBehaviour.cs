using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    Final Harvest
    Franz Cadiente 301098663
    Sydney Huang 301068497
    Kautuk Udavant 301072587

    Date last modified: 03/21/21
 */

public class PlayerBehaviour : MonoBehaviour
{
    public CharacterController controller;

    [Header("Controls")]
    public Joystick joystick;
    public float horizontalSensitivity;
    public float verticalSensitivity;

    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public LayerMask tireMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isOnTire;

    private Footsteps footsteps;
    public AudioSource hurtSound;
    public AudioSource bounceSound;

    [Header("MiniMap")]
    public GameObject miniMap;

    [Header("HealthBar")]
    public HealthBarScreenSpaceController healthBar;

    [Header("Player Abilities")]
    [Range(0, 100)]
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footsteps = GetComponent<Footsteps>();
        healthBar = FindObjectOfType<HealthBarScreenSpaceController>();
    }

    // Update is called once per frame - once every 16.6666ms

    void Update()
    {
        aliveCheck();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        isOnTire = Physics.CheckSphere(groundCheck.position, groundRadius, tireMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);
        //if (Input.GetButton("Jump") && isGrounded)
        //{
        //    Jump();
        //}

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    ToggleMinimap();
        //}
    }

    /*if (Input.GetButton("Jump") && isGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        footsteps.Jump();
    }

    if (Input.GetButton("Jump") && isOnTire)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * 5 * -2.0f * gravity);
        footsteps.Jump();
        bounceSound.Play();
    }*/
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        //jumpSound.Play();
    }
    void ToggleMinimap()
    {
        // toggle the MiniMap on/off
        miniMap.SetActive(!miniMap.activeInHierarchy);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void TakeDamage(int dmg)
    {
        hurtSound.Play();
        health -= dmg;
        healthBar.TakeDamage(dmg);
        if (health < 0)
        {
            health = 0;
        }

    }

    public void aliveCheck()
    {
        if (health <=0)
        {
            //Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Game Over");
            Time.timeScale = 0f;
        }
    }
    public void OnJumpButtonPressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    public void OnMapButtonPressed()
    {
        ToggleMinimap();
    }

    public void OnEscapeButtonPressed()
    {
        SceneManager.LoadScene("Game Over");
    }


}
