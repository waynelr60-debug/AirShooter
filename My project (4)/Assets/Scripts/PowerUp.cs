using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float lifeTime = 8f; // powerup hilang otomatis
    public int bonusDamage = 2;
    public float duration = 5f; // durasi efek

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPowerUp buff = collision.GetComponent<PlayerPowerUp>();

            if (buff != null)
            {
                buff.ActivatePowerUp(bonusDamage, duration);
            }

            Destroy(gameObject);
        }
    }
}
