using UnityEngine;
using System.Collections;

public class PlayerPowerUp : MonoBehaviour
{
    [Header("Components")]
    // Asumsi: PlayerBullet adalah nama script pelurumu
    // Jika error, ganti 'PlayerBullet' dengan nama script yang benar atau 'MonoBehaviour'
    public PlayerBullet shooter;
    public GameObject auraEffect;

    [Header("Scaling Settings")]
    public float scaleMultiplier = 1.5f; // Pesawat membesar 1.5x
    public float scaleDuration = 0.5f;   // Durasi animasi membesar (biar halus)

    private int originalDamage = 1;
    private Vector3 originalScale;       // Menyimpan ukuran asli
    private bool isBuffActive = false;

    void Start()
    {
        // Simpan data asli
        if (shooter != null) originalDamage = shooter.damage; // Pastikan shooter di-assign di Inspector
        originalScale = transform.localScale;

        if (auraEffect != null)
            auraEffect.SetActive(false);
    }

    public void ActivatePowerUp(int newDamage, float duration)
    {
        if (!isBuffActive)
            StartCoroutine(PowerUpRoutine(newDamage, duration));
        else
        {
            StopAllCoroutines();
            // Kembalikan ke normal dulu sebentar biar reset bersih (opsional)
            transform.localScale = originalScale;
            StartCoroutine(PowerUpRoutine(newDamage, duration));
        }
    }

    private IEnumerator PowerUpRoutine(int newDamage, float duration)
    {
        isBuffActive = true;
        if (auraEffect != null) auraEffect.SetActive(true);

        // 1. Naikkan Damage
        if (shooter != null) shooter.damage = newDamage;

        // 2. SKALASI: Membesar (Pakai Lerp biar halus)
        float timer = 0;
        Vector3 targetScale = originalScale * scaleMultiplier;

        while (timer < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / scaleDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale; // Pastikan pas di target

        // --- TUNGGU DURASI HABIS ---
        yield return new WaitForSeconds(duration);

        // 3. Reset Damage
        if (shooter != null) shooter.damage = originalDamage;
        if (auraEffect != null) auraEffect.SetActive(false);

        // 4. SKALASI: Mengecil Kembali
        timer = 0;
        while (timer < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / scaleDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale; // Pastikan kembali ke asli

        isBuffActive = false;
    }
}