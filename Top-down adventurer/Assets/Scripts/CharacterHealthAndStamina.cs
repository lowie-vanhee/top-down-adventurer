using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthAndStamina : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxStamina = 100;
    public int currentStamina;

    public HealthBar healthBar;
    public StaminaBar staminaBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentStamina = 0;
        staminaBar.setMaxStamina(maxStamina);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            removeHealth(10);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            addStamina(20);
        }
    }

    public void removeHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        healthBar.setHealth(currentHealth);
    }

    public void addHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
    }

    public void addStamina(int stamina)
    {
        currentStamina += stamina;
        if (currentStamina > maxStamina)
            currentStamina = maxStamina;
        staminaBar.setStamina(currentStamina);
    }

    public void removeStamina(int stamina)
    {
        currentStamina -= stamina;
        if (currentStamina < 0)
            currentStamina = 0;
        staminaBar.setStamina(currentStamina);
    }

    public int getMaxStamina()
    {
        return maxStamina;
    }

    public int getStamina()
    {
        return currentStamina;
    }
}
