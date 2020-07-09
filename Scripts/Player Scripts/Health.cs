using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private int defaultHealth = 100;
    public int currentHealth;
    private int maxHealth;
    private int healthModifier;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = defaultHealth + healthModifier;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public int GetMaxHealth()
    { 
    return maxHealth;
    }

    public int GetHealthModifier()
    {
        return healthModifier;
    }

    void SetHealthModifier(int value)
    {
        healthModifier += value;
        maxHealth += healthModifier;
    }
}
