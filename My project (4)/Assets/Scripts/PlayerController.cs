using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float speed = 5f;

    [Header("Rotation Settings")]
    public float rotateSpeed = 180f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.25f;

    [Header("Sound Settings")]
    public AudioSource audioSource;
    public AudioClip shootSFX;

    private float nextFireTime = 0f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
        HandleRotation();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }

    void HandleRotation()
    {
        // P → rotasi kanan
        if (Input.GetKey(KeyCode.P))
        {
            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }

        // O → rotasi kiri
        if (Input.GetKey(KeyCode.O))
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
    }

    void HandleShooting()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("❌ bulletPrefab atau firePoint belum dihubungkan!");
            return;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * bulletSpeed;
        }

        if (audioSource != null && shootSFX != null)
        {
            audioSource.PlayOneShot(shootSFX);
        }

        Destroy(bullet, 3f);
    }
}
