using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public int points = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // BARU: Lapor ke GameManager buat nambah skor
        if (GameManager.instance != null)
        {
            GameManager.instance.AddScore(points);
        }

        // Efek ledakan, dll...
        Destroy(gameObject);
    }
}
