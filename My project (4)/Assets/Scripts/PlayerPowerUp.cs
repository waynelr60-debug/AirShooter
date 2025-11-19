using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public PlayerBullet shooter;   // script tembak kamu yang punya bulletDamage
    public GameObject auraEffect;

    private int originalDamage = 1;
    private bool isBuffActive = false;

    void Start()
    {
        originalDamage = shooter.damage;

        if (auraEffect != null)
            auraEffect.SetActive(false);
    }

    public void ActivatePowerUp(int newDamage, float duration)
    {
        if (!isBuffActive)
            StartCoroutine(PowerUpRoutine(newDamage, duration));
        else
            StopAllCoroutines();  // reset timer jika dapat buff lagi
    }

    private System.Collections.IEnumerator PowerUpRoutine(int newDamage, float duration)
    {
        isBuffActive = true;

        auraEffect.SetActive(true);   // 🔥 Nyalakan aura

        shooter.damage = newDamage;

        yield return new WaitForSeconds(duration);

        shooter.damage = originalDamage;
        auraEffect.SetActive(false);

        isBuffActive = false;
    }
}
