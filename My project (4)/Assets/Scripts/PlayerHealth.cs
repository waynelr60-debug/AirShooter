using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " terkena damage! Sisa HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " mati!");

        // 🔥 PANGGIL GAME OVER UI
        GameManager.instance.GameOver();

        // Sembunyikan player (lebih aman daripada destroy)
        gameObject.SetActive(false);
    }
}
