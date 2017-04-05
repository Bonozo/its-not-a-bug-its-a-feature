using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAutoDestroy : MonoBehaviour
{
    public float autoDestructCheckInterval = 0.5f;

    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem.main.loop)
        {
            Debug.LogError("Particle system can't self destruct if it loops");
        }
        else
        {
            StartCoroutine(TickDelay());
        }
    }

    private IEnumerator TickDelay()
    {
        yield return new WaitForSeconds(particleSystem.main.duration);
        StartCoroutine(AliveCheck());
    }

    private IEnumerator AliveCheck()
    {
        while (particleSystem.IsAlive())
        {
            yield return new WaitForSeconds(autoDestructCheckInterval);
        }

        Destroy(gameObject);
    }
}
