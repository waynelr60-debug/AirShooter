using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 2f;
    public int health = 3;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1.5f;
    private float fireTimer = 0f;

    [Header("Movement Route")]
    public bool moveRight = false;
    public bool moveLeft = false;
    public bool moveDown = true;
    public bool moveCircle = false;

    void Update()
    {
        // --- Movement ---
        if (moveRight) transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (moveLeft) transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (moveDown) transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (moveCircle) transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);

        // --- Shooting ---
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null)
        {
            Debug.LogError("❌ Enemy bulletPrefab atau shootPoint belum dihubungkan!");
            return;
        }

        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
