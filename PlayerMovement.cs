using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    Vector3 veclocity;

    Vector3 pushDirection;

    public float gravity = -9.81f;
    public float playerSpeed = 10f;
    public float jumpHeight = 3f;
    public float groundDist = 0.4f;

    public float knockbackSpeed;


    public int maxHealth = 100;
    public int currentHealth;

    public Rigidbody playerRigidbody;

    public HealthBar healthBar;

    public Transform goundCheck;
    public LayerMask groundMask;



    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(goundCheck.position, groundDist, groundMask);

        if (isGrounded && veclocity.y < 0)
        {
            veclocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");



        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            veclocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            Debug.Log("Jumped");


        }



        veclocity.y += gravity * Time.deltaTime;

        controller.Move(veclocity * Time.deltaTime);

    }
   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {

            Debug.Log("knocback");

            playerRigidbody = GetComponent<Rigidbody>();

            pushDirection = Vector3.back * knockbackSpeed;
            playerRigidbody.AddForce(pushDirection * 100);
            TakeDamage(10);
            
        }

    }
    
}
