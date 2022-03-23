using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float currentHealth = 1.0f;
    private float _maxHealth = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log(damage + " damage taken.");
        Debug.Log("current health = " + currentHealth);
    }

    public void Heal(float amount)
    {
        float _oldHealth = amount;

        if (currentHealth < _maxHealth)
        {
            // heal for amount
            currentHealth = currentHealth + amount;

            if (currentHealth > _maxHealth)
            {
                // make sure the user doesn't go past max health
                currentHealth = _maxHealth;
            }

            Debug.Log((currentHealth-_oldHealth) + " health healed.");
            Debug.Log("current health = " + currentHealth);
        }
    }
}
