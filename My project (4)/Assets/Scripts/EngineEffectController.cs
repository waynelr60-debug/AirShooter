using UnityEngine;

public class EngineEffectController : MonoBehaviour
{
    public ParticleSystem engineEffect;

    void Update()
    {
        // Jika player menekan tombol W (maju)
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)

        {
            if (!engineEffect.isPlaying)
                engineEffect.Play();
        }
        else
        {
            if (engineEffect.isPlaying)
                engineEffect.Stop();
        }
    }
}
