using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Shield")]
    public bool hasShield = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Jika memiliki shield, shield akan hilang dan tidak menerima damage
        if (hasShield)
        {
            hasShield = false;
            Debug.Log("Shield hancur!");
            return;
        }

        currentHealth -= damage;

        Debug.Log("HP : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void ActivateShield()
    {
        hasShield = true;
    }

    void Die()
    {
        Debug.Log("Game Over");

        // Nanti akan kita ganti menjadi GameOver UI
        gameObject.SetActive(false);
    }
}