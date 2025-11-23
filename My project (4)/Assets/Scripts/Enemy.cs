using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 2f;    

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float fireRate = 2f;
    private float fireTimer = 0f;

    [Header("Movement Route")]
    public bool moveRight = false;
    public bool moveLeft = false;
    public bool moveDown = true;
    public bool moveCircle = false;

    public float bottomBound = -8f;

    void Update()
    {
        // --- Movement ---
        if (moveRight) transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (moveLeft) transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (moveDown) transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (moveCircle) transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.deltaTime);

        // --- Shooting ---
        fireTimer += Time.deltaTime;
        //print("Enemy.cs: deltaTime: " + Time.deltaTime);
        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
        if (transform.position.y < bottomBound) Destroy(gameObject);
        
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

    
}
