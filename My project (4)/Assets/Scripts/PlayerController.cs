using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float speed = 5f;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.25f; // bisa ditembakkan 4x per detik

    private float nextFireTime = 0f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;
    }

    void HandleShooting()
    {
        // pastikan bullet dan firepoint sudah terisi
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("❌ bulletPrefab atau firePoint belum terhubung di Inspector!");
            return;
        }

        // bisa tembak terus selama tombol spasi ditekan
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

        Destroy(bullet, 3f); // hapus peluru setelah 3 detik
    }
}
