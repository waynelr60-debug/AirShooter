using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    // Sesuaikan angka ini dengan ukuran layar kamera kamu
    // Cara cari angkanya: Geser player di Scene view sampai pinggir, catat nilai X dan Y-nya.
    public float screenRight = 8.9f;
    public float screenLeft = -8.9f;
    public float screenTop = 5f;
    public float screenBottom = -5f;

    void Update()
    {
        // Ambil posisi player saat ini
        Vector3 newPos = transform.position;

        // Cek Kanan & Kiri
        if (newPos.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        else if (newPos.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        // Cek Atas & Bawah
        if (newPos.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        else if (newPos.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        // Terapkan posisi baru
        transform.position = newPos;
    }
}