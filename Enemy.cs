using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public float maxHealth = 50f;

    public GameObject healthBar;
    public Slider slider;

    private float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    public ParticleSystem deathBoom;


    private SpawnManager SpawnManagerScript;


    private void Start()
    {
        slider.value = maxHealth;

        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        SpawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        speed = SpawnManagerScript.enemySpeed;


    }
    void Update()
    {
        slider.value = maxHealth;


        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    public void TakeDamage(float amount)
    {

        maxHealth -= amount;
        
        if (maxHealth < 50)
        {
            healthBar.gameObject.SetActive(true);
        }

        if (maxHealth <= 0f)
        {
            Die();
        }


    }
    void Die()
    {

        ParticleSystem death = Instantiate(deathBoom, transform.position, transform.rotation) as ParticleSystem;


        death.Play();

        Destroy(gameObject);



    }

    

}
