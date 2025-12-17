using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        // Tekan angka 1 (bukan numpad)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainGame");
        }

        // (opsional) kalau mau bisa dari numpad juga
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
