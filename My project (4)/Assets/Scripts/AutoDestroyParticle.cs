using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.1f); // hancur setelah 1 detik
    }
}
