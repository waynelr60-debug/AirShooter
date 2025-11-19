using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public float duration = 5f; // berapa lama buff berlaku
    public int bonusDamage = 2; // damage peluru ketika buff

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowerUp power = collision.GetComponent<PlayerPowerUp>();

            if (power != null)
            {
                power.ActivatePowerUp(bonusDamage, duration);
            }

            Destroy(gameObject); // hancurkan power-up
        }
    }
}
