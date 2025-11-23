using UnityEngine;
using System.Collections;

public class PlayerManeuver : MonoBehaviour
{
    [Header("Settings")]
    public float rollDuration = 0.5f; // Seberapa cepat putarannya
    public float cooldownTime = 2f;   // Jeda biar gak spam tombol R

    private bool isRolling = false;
    private float cooldownTimer = 0f;
    private Collider2D playerCollider; // Untuk fitur "Invincible" saat putar

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Kurangi timer cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Cek Input Keyboard "R"
        if (Input.GetKeyDown(KeyCode.R) && !isRolling && cooldownTimer <= 0)
        {
            StartCoroutine(PerformBarrelRoll());
        }
    }

    IEnumerator PerformBarrelRoll()
    {
        isRolling = true;
        cooldownTimer = cooldownTime; // Set cooldown

        // Opsional: Matikan collider biar TEMBUS PELURU (Invincible) saat putar
        if (playerCollider != null) playerCollider.enabled = false;

        float elapsed = 0f;
        Quaternion startRotation = transform.rotation;

        // ROTASI: Putar 360 derajat di sumbu Z
        while (elapsed < rollDuration)
        {
            elapsed += Time.deltaTime;
            float percent = elapsed / rollDuration;

            // Rumus Rotasi Z
            float zRotation = Mathf.Lerp(0, 360, percent);
            transform.rotation = startRotation * Quaternion.Euler(0, 0, zRotation);

            yield return null;
        }

        // Kembalikan ke posisi semula
        transform.rotation = startRotation;

        // Nyalakan lagi collidernya
        if (playerCollider != null) playerCollider.enabled = true;

        isRolling = false;
    }
}