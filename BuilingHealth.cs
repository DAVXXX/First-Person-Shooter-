using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuilingHealth : MonoBehaviour
{

    public float maxHealth = 50f;

    public GameObject healthBar;
    public Slider slider;

    private Rigidbody buildingRb;



    // Start is called before the first frame update
    void Start()
    {
        slider.value = maxHealth;

        buildingRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = maxHealth;
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


        Destroy(gameObject);



    }





}
