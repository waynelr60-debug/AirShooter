using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;  // kecepatan naik background
    public float resetHeight = 10f; // tinggi sprite background

    void Update()
    {
        // Gerakkan background ke bawah
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Jika background sudah turun terlalu jauh, reset ke atas
        if (transform.position.y < -resetHeight)
        {
            transform.position = new Vector3(
                transform.position.x,
                resetHeight,
                transform.position.z
            );
        }
    }
}
