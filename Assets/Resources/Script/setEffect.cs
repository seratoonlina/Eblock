using UnityEngine;

public class setEffect : MonoBehaviour
{
    public ParticleSystem particle;
    public void enable()
    {
        particle.Play();
    }

    public void disable()
    {
        particle.Stop();
    }
}
